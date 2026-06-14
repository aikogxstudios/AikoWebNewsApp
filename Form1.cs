using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace AikoWebNewsApp;

public partial class Form1 : Form
{
    private readonly string _dataRoot;
    private readonly string _currentDay;
    private readonly string _dayPath;
    private TextBox _notesBox = null!;
    private ListBox _assetsList = null!;
    private Label _statusLabel = null!;
    private Label _recommendationLabel = null!;
    private TextBox _previewWeb = null!;
    private TextBox _previewDiscord = null!;
    private TextBox _previewX = null!;
    private TextBox _aikoResponseBox = null!;

    private sealed record EditorialDiagnostic(
        int NoteCount,
        int CaptureCount,
        int VideoCount,
        string Summary,
        string InformationLevel,
        string RecommendedType,
        string Reason,
        string MissingForStrongWebEntry,
        string PossibleContentToday);

    private static readonly string[] RootFolders =
    [
        "Inbox",
        "Dias",
        "Borradores",
        "Publicados",
        "Plantillas",
        "Exportados",
        "Config",
        "Logs"
    ];

    private static readonly string[] DayFolders =
    [
        "Capturas",
        "Videos",
        "Notas",
        "Seleccionado",
        "Salida"
    ];

    public Form1()
    {
        InitializeComponent();
        _dataRoot = AppContext.BaseDirectory;
        _currentDay = DateTime.Now.ToString("yyyy-MM-dd");
        _dayPath = Path.Combine(_dataRoot, "Dias", _currentDay);

        BuildUi();
        EnsureBaseData();
        EnsureDay(_currentDay);
        LoadNotes();
        RefreshAssetsList();
        LoadPreviews();
        SetStatus("Listo. Trabajando sobre el día " + _currentDay + ".");
    }

    private void BuildUi()
    {
        BackColor = Color.FromArgb(15, 18, 32);
        ForeColor = Color.FromArgb(235, 241, 255);
        Font = new Font("Segoe UI", 10F);

        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 3,
            Padding = new Padding(18),
            BackColor = BackColor
        };
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 104F));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        Controls.Add(root);

        var header = new Panel { Dock = DockStyle.Fill, BackColor = BackColor };
        root.SetColumnSpan(header, 2);
        root.Controls.Add(header, 0, 0);

        header.Controls.Add(new Label
        {
            Text = "Aiko Web News App",
            AutoSize = true,
            Font = new Font("Segoe UI", 22F, FontStyle.Bold),
            ForeColor = Color.FromArgb(112, 232, 255),
            Location = new Point(0, 4)
        });

        header.Controls.Add(new Label
        {
            Text = "Organiza avances de Caos Entre Reinos: Reborn y prepara borradores locales para publicar manualmente.",
            AutoSize = true,
            Font = new Font("Segoe UI", 10F),
            ForeColor = Color.FromArgb(207, 196, 255),
            Location = new Point(3, 52)
        });

        _recommendationLabel = new Label
        {
            Text = "Recomendación: pendiente de diagnóstico editorial",
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(255, 122, 218),
            Location = new Point(3, 76)
        };
        header.Controls.Add(_recommendationLabel);

        var left = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 3,
            ColumnCount = 1,
            Padding = new Padding(0, 0, 14, 0),
            BackColor = BackColor
        };
        left.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        left.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        left.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
        root.Controls.Add(left, 0, 1);

        left.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Text = "Día actual: " + _currentDay,
            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
            ForeColor = Color.FromArgb(255, 122, 218),
            TextAlign = ContentAlignment.MiddleLeft
        }, 0, 0);

        _notesBox = new TextBox
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            AcceptsReturn = true,
            AcceptsTab = true,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.FromArgb(23, 28, 48),
            ForeColor = Color.FromArgb(245, 247, 255),
            Font = new Font("Consolas", 10F)
        };
        left.Controls.Add(_notesBox, 0, 1);

        var noteButtons = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            BackColor = BackColor
        };
        noteButtons.Controls.Add(MakeButton("Guardar nota rápida", SaveNotes));
        noteButtons.Controls.Add(MakeButton("Abrir carpeta del día", () => OpenFolder(_dayPath)));
        noteButtons.Controls.Add(MakeButton("Abrir salida", () => OpenFolder(Path.Combine(_dayPath, "Salida"))));
        left.Controls.Add(noteButtons, 0, 2);

        var right = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 5,
            ColumnCount = 1,
            BackColor = BackColor
        };
        right.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        right.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
        right.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
        right.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
        right.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
        root.Controls.Add(right, 1, 1);

        right.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Text = "Material detectado",
            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
            ForeColor = Color.FromArgb(112, 232, 255),
            TextAlign = ContentAlignment.MiddleLeft
        }, 0, 0);

        _assetsList = new ListBox
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(23, 28, 48),
            ForeColor = Color.FromArgb(235, 241, 255),
            BorderStyle = BorderStyle.FixedSingle,
            Font = new Font("Consolas", 10F)
        };
        right.Controls.Add(_assetsList, 0, 1);

        var previewTabs = new TabControl { Dock = DockStyle.Fill };
        _previewWeb = MakePreviewBox();
        _previewDiscord = MakePreviewBox();
        _previewX = MakePreviewBox();
        previewTabs.TabPages.Add(MakePreviewPage("Entrada web", _previewWeb));
        previewTabs.TabPages.Add(MakePreviewPage("Discord", _previewDiscord));
        previewTabs.TabPages.Add(MakePreviewPage("X", _previewX));
        previewTabs.TabPages.Add(MakeAikoResponsePage());
        right.Controls.Add(previewTabs, 0, 2);

        var importButtons = new FlowLayoutPanel { Dock = DockStyle.Fill, BackColor = BackColor };
        importButtons.Controls.Add(MakeButton("Crear día actual", () =>
        {
            EnsureDay(_currentDay);
            RefreshAssetsList();
            SetStatus("Día creado correctamente.");
        }));
        importButtons.Controls.Add(MakeButton("Importar capturas", ImportCaptures));
        importButtons.Controls.Add(MakeButton("Importar vídeos", ImportVideos));
        importButtons.Controls.Add(MakeButton("Preparar contenido", PrepareContent, true));
        importButtons.Controls.Add(MakeButton("Generar paquete para Aiko", GenerateAikoPackage, true));
        right.Controls.Add(importButtons, 0, 3);

        var copyButtons = new FlowLayoutPanel { Dock = DockStyle.Fill, BackColor = BackColor };
        copyButtons.Controls.Add(MakeButton("Copiar entrada web", () => CopyOutput("entrada_web.md")));
        copyButtons.Controls.Add(MakeButton("Copiar Discord", () => CopyOutput("post_discord.md")));
        copyButtons.Controls.Add(MakeButton("Copiar X", () => CopyOutput("post_x.md")));
        copyButtons.Controls.Add(MakeButton("Ver diagnóstico editorial", OpenEditorialDiagnostic));
        copyButtons.Controls.Add(MakeButton("Marcar como publicado", MarkAsPublished));
        right.Controls.Add(copyButtons, 0, 4);

        _statusLabel = new Label
        {
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.FromArgb(207, 196, 255)
        };
        root.SetColumnSpan(_statusLabel, 2);
        root.Controls.Add(_statusLabel, 0, 2);
    }

    private static TextBox MakePreviewBox()
    {
        return new TextBox
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.FromArgb(20, 24, 42),
            ForeColor = Color.FromArgb(235, 241, 255),
            Font = new Font("Consolas", 9.5F),
            Text = "Prepara contenido para ver aquí la vista previa."
        };
    }

    private static TabPage MakePreviewPage(string title, TextBox preview)
    {
        var page = new TabPage(title)
        {
            BackColor = Color.FromArgb(15, 18, 32),
            ForeColor = Color.White
        };
        page.Controls.Add(preview);
        return page;
    }

    private TabPage MakeAikoResponsePage()
    {
        var page = new TabPage("Respuesta de Aiko")
        {
            BackColor = Color.FromArgb(15, 18, 32),
            ForeColor = Color.White
        };

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1,
            BackColor = Color.FromArgb(15, 18, 32),
            Padding = new Padding(6)
        };
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        page.Controls.Add(layout);

        _aikoResponseBox = new TextBox
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            AcceptsReturn = true,
            AcceptsTab = true,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.FromArgb(20, 24, 42),
            ForeColor = Color.FromArgb(235, 241, 255),
            Font = new Font("Consolas", 9.5F),
            Text = "Pega aquí la respuesta de ChatGPT/Aiko y pulsa Guardar respuesta de Aiko."
        };
        layout.Controls.Add(_aikoResponseBox, 0, 0);

        var buttons = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            BackColor = Color.FromArgb(15, 18, 32)
        };
        buttons.Controls.Add(MakeButton("Guardar respuesta de Aiko", SaveAikoResponse, true));
        buttons.Controls.Add(MakeButton("Copiar paquete para Aiko", CopyAikoPackage));
        buttons.Controls.Add(MakeButton("Abrir paquete para Aiko", OpenAikoPackage));
        layout.Controls.Add(buttons, 0, 1);

        return page;
    }

    private Button MakeButton(string text, Action action, bool primary = false)
    {
        var button = new Button
        {
            Text = text,
            AutoSize = true,
            Height = 36,
            Margin = new Padding(0, 5, 8, 5),
            Padding = new Padding(12, 4, 12, 4),
            FlatStyle = FlatStyle.Flat,
            BackColor = primary ? Color.FromArgb(113, 57, 217) : Color.FromArgb(30, 39, 72),
            ForeColor = Color.White,
            Cursor = Cursors.Hand
        };
        button.FlatAppearance.BorderColor = primary ? Color.FromArgb(255, 122, 218) : Color.FromArgb(74, 111, 170);
        button.Click += (_, _) => SafeRun(action);
        return button;
    }

    private void SafeRun(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Log(ex.ToString());
            MessageBox.Show(this, "No se pudo completar la acción. Detalle: " + ex.Message, "Aiko Web News App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SetStatus("Error controlado. Revisa Logs si se repite.");
        }
    }

    private void EnsureBaseData()
    {
        foreach (var folder in RootFolders)
        {
            Directory.CreateDirectory(Path.Combine(_dataRoot, folder));
        }

        EnsureConfig();
        EnsureTemplates();
    }

    private void EnsureDay(string day)
    {
        var dayRoot = Path.Combine(_dataRoot, "Dias", day);
        Directory.CreateDirectory(dayRoot);
        foreach (var folder in DayFolders)
        {
            Directory.CreateDirectory(Path.Combine(dayRoot, folder));
        }
    }

    private void EnsureConfig()
    {
        var configPath = Path.Combine(_dataRoot, "Config", "config.json");
        if (File.Exists(configPath))
        {
            return;
        }

        var config = new
        {
            idioma_por_defecto = "español",
            proyecto = "Caos Entre Reinos: Reborn",
            estudio = "AikoGx Studios",
            modo_de_generacion = "plantilla local"
        };
        File.WriteAllText(configPath, JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8);
    }

    private void EnsureTemplates()
    {
        var templates = new Dictionary<string, string>
        {
            ["plantilla_entrada_web.md"] = "# {titulo}\n\n## Resumen corto\n{resumen}\n\n## Devlog\n{entrada}\n",
            ["plantilla_discord.md"] = "{texto_discord}\n",
            ["plantilla_x.md"] = "{texto_x}\n",
            ["plantilla_tiktok.md"] = "{ideas_tiktok}\n",
            ["plantilla_youtube_shorts.md"] = "{ideas_youtube_shorts}\n"
        };

        foreach (var item in templates)
        {
            var path = Path.Combine(_dataRoot, "Plantillas", item.Key);
            if (!File.Exists(path))
            {
                File.WriteAllText(path, item.Value, Encoding.UTF8);
            }
        }
    }

    private void LoadNotes()
    {
        var notePath = GetNotePath();
        if (File.Exists(notePath))
        {
            _notesBox.Text = File.ReadAllText(notePath, Encoding.UTF8);
        }
    }

    private void SaveNotes()
    {
        EnsureDay(_currentDay);
        File.WriteAllText(GetNotePath(), _notesBox.Text, Encoding.UTF8);
        SetStatus(string.IsNullOrWhiteSpace(_notesBox.Text) ? "No hay notas todavía. Nota vacía guardada." : "Nota guardada.");
    }

    private string GetNotePath() => Path.Combine(_dayPath, "Notas", "nota_rapida.md");

    private void ImportCaptures()
    {
        ImportFiles("Importar capturas", Path.Combine(_dayPath, "Capturas"), "Imágenes|*.png;*.jpg;*.jpeg;*.webp;*.bmp;*.gif|Todos los archivos|*.*", "Capturas importadas.");
    }

    private void ImportVideos()
    {
        ImportFiles("Importar vídeos", Path.Combine(_dayPath, "Videos"), "Vídeos|*.mp4;*.mov;*.mkv;*.webm;*.avi|Todos los archivos|*.*", "Vídeos importados.");
    }

    private void ImportFiles(string title, string targetFolder, string filter, string successMessage)
    {
        using var dialog = new OpenFileDialog
        {
            Title = title,
            Filter = filter,
            Multiselect = true
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        EnsureDay(_currentDay);
        Directory.CreateDirectory(targetFolder);
        foreach (var source in dialog.FileNames)
        {
            File.Copy(source, GetAvailableFileName(targetFolder, Path.GetFileName(source)));
        }

        RefreshAssetsList();
        SetStatus(successMessage + " " + dialog.FileNames.Length + " archivo(s).");
    }

    private static string GetAvailableFileName(string folder, string fileName)
    {
        var baseName = Path.GetFileNameWithoutExtension(fileName);
        var extension = Path.GetExtension(fileName);
        var target = Path.Combine(folder, fileName);
        var index = 1;

        while (File.Exists(target))
        {
            target = Path.Combine(folder, $"{baseName}_{index}{extension}");
            index++;
        }

        return target;
    }

    private void RefreshAssetsList()
    {
        _assetsList.Items.Clear();

        var captures = GetFiles("Capturas");
        var videos = GetFiles("Videos");

        foreach (var file in captures)
        {
            _assetsList.Items.Add("[captura] " + Path.GetFileName(file));
        }

        foreach (var file in videos)
        {
            _assetsList.Items.Add("[vídeo]   " + Path.GetFileName(file));
        }

        if (captures.Length == 0)
        {
            _assetsList.Items.Add("No hay capturas disponibles.");
        }

        if (videos.Length == 0)
        {
            _assetsList.Items.Add("No se detectaron vídeos.");
        }
    }

    private string[] GetFiles(string daySubfolder)
    {
        var folder = Path.Combine(_dayPath, daySubfolder);
        return Directory.Exists(folder) ? Directory.GetFiles(folder).OrderBy(Path.GetFileName).ToArray() : [];
    }

    private void PrepareContent()
    {
        EnsureDay(_currentDay);
        SaveNotes();

        var output = Path.Combine(_dayPath, "Salida");
        Directory.CreateDirectory(output);

        var notes = _notesBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(notes))
        {
            notes = "Todavía no hay notas suficientes. Añade una nota del día para generar una entrada más completa.";
        }

        var captures = GetFiles("Capturas").Select(Path.GetFileName).Where(x => x is not null).Cast<string>().ToList();
        var videos = GetFiles("Videos").Select(Path.GetFileName).Where(x => x is not null).Cast<string>().ToList();
        var mainImage = captures.FirstOrDefault() ?? "No se detectaron capturas";
        var highlight = ExtractHighlight(notes);

        var webEntry = BuildWebEntry(notes, captures, videos, mainImage, highlight);
        var discordPost = BuildDiscordPost(highlight);
        var xPost = BuildXPost(highlight);

        Write(output, "entrada_web.md", webEntry);
        Write(output, "post_discord.md", discordPost);
        Write(output, "post_x.md", xPost);
        Write(output, "ideas_tiktok.md", BuildTikTokIdeas(captures, videos, highlight));
        Write(output, "ideas_youtube_shorts.md", BuildShortsIdeas(captures, videos, highlight));
        Write(output, "resumen_del_dia.md", BuildDailySummary(notes, captures, videos, highlight));
        Write(output, "imagenes_recomendadas.md", BuildRecommendedImages(captures, mainImage));
        var diagnostic = WriteEditorialDiagnostic(output);

        CopyDraftsToBorradores(output);
        LoadPreviews();
        RefreshAssetsList();
        SetRecommendation(diagnostic.RecommendedType);
        SetStatus("Borrador base generado.");
    }

    private void GenerateAikoPackage()
    {
        EnsureDay(_currentDay);
        SaveNotes();

        var output = Path.Combine(_dayPath, "Salida");
        Directory.CreateDirectory(output);

        var diagnostic = WriteEditorialDiagnostic(output);
        var package = BuildAikoPackage();
        var packagePath = GetAikoPackagePath();
        File.WriteAllText(packagePath, package, Encoding.UTF8);
        SetRecommendation(diagnostic.RecommendedType);

        TryCopyToClipboard(package, "Paquete para Aiko generado y copiado al portapapeles. Pega este paquete en ChatGPT/Aiko para obtener contenido mejor redactado.");
    }

    private string BuildAikoPackage()
    {
        var notes = ReadAllNotes();
        var captures = GetFiles("Capturas").Select(Path.GetFileName).Where(x => x is not null).Cast<string>().ToList();
        var videos = GetFiles("Videos").Select(Path.GetFileName).Where(x => x is not null).Cast<string>().ToList();
        var existingOutputs = ReadExistingOutputFiles();
        var diagnosticPath = GetEditorialDiagnosticPath();
        var diagnostic = File.Exists(diagnosticPath) ? File.ReadAllText(diagnosticPath, Encoding.UTF8).Trim() : BuildEditorialDiagnosticMarkdown(CreateEditorialDiagnostic());

        return $"""
        # Paquete para Aiko - Devlog del día

        Proyecto: Caos Entre Reinos: Reborn
        Estudio: AikoGx Studios
        Fecha: {_currentDay}

        ## Notas del día

        {notes}

        ## Capturas disponibles

        {FormatFileList(captures, "No se detectaron capturas.")}

        ## Vídeos disponibles

        {FormatFileList(videos, "No se detectaron vídeos.")}

        ## Diagnóstico editorial local

        {diagnostic}

        ## Borradores base existentes

        {existingOutputs}

        ## Objetivo

        Preparar contenido real y prudente para el formato que tenga sentido según el material disponible:

        * entrada web de AikoGx Studios
        * post para Discord
        * post para X
        * ideas para TikTok
        * ideas para YouTube Shorts
        * recomendación de imagen principal
        * resumen del día

        ## Instrucciones para Aiko

        Antes de redactar, analiza el material disponible y decide si conviene hacer un devlog completo, un avance corto, solo redes, ideas de vídeo, nota interna o no publicar todavía. No fuerces una entrada larga si la información es poca. No repitas la misma idea muchas veces. Si el material no da para web, dilo claramente y prepara solo el formato adecuado.

        Redacta contenido en español con tono cercano, indie, honesto y creativo.
        No rellenes por rellenar.
        No conviertas una frase corta en un artículo largo.
        No repitas "no hay capturas" en todas las secciones.
        No inventes sistemas, mecánicas ni lore.
        No vendas humo.
        No prometas fechas.
        No digas que algo está terminado si solo está en prueba.
        Evita spoilers fuertes del lore.
        Usa solo la información del material del día.
        Si falta información, haz una versión prudente y pide qué dato falta.
        El contenido debe quedar listo para revisar y publicar manualmente.
        Aprovecha lo más fuerte del material.
        Si lo más fuerte es humor o rareza, úsalo como post corto.
        Si lo más fuerte es una captura, recomienda formato visual.
        Si lo más fuerte es una mecánica, recomienda devlog.
        Si lo más fuerte es una duda o idea, recomienda nota interna.

        ## Formato de salida que debe devolver Aiko

        Aiko debe devolver primero:

        # Diagnóstico editorial

        * Tipo recomendado:
        * Nivel de información:
        * ¿Publicar en web?: Sí/No
        * ¿Publicar en redes?: Sí/No
        * ¿Crear vídeo corto?: Sí/No
        * Motivo:

        # Contenido recomendado

        Solo genera las secciones que tengan sentido.

        Si recomiendas devlog completo:

        * Entrada web completa
        * Post Discord
        * Post X
        * Ideas TikTok
        * Ideas YouTube Shorts
        * Imagen recomendada

        Si recomiendas avance corto:

        * Mini entrada web o update corto
        * Post Discord
        * Post X
        * 1 o 2 ideas de vídeo

        Si recomiendas solo redes:

        * Post Discord
        * Post X
        * 1 idea TikTok opcional
        * Nota de por qué no conviene web

        Si recomiendas idea para vídeo:

        * Idea de vídeo corto
        * Qué mostrar
        * Texto en pantalla
        * Post de apoyo para Discord o X si tiene sentido

        Si recomiendas nota interna:

        * Resumen interno
        * Qué información falta
        * Qué capturas conviene hacer

        Si recomiendas no publicar todavía:

        * Motivo
        * Lista de material necesario para publicar luego
        """.Trim() + Environment.NewLine;
    }

    private EditorialDiagnostic WriteEditorialDiagnostic(string output)
    {
        var diagnostic = CreateEditorialDiagnostic();
        File.WriteAllText(Path.Combine(output, "diagnostico_editorial.md"), BuildEditorialDiagnosticMarkdown(diagnostic), Encoding.UTF8);
        return diagnostic;
    }

    private EditorialDiagnostic CreateEditorialDiagnostic()
    {
        var noteContents = ReadNoteContents();
        var captures = GetFiles("Capturas").Select(Path.GetFileName).Where(x => x is not null).Cast<string>().ToList();
        var videos = GetFiles("Videos").Select(Path.GetFileName).Where(x => x is not null).Cast<string>().ToList();
        var noteCount = noteContents.Count;
        var captureCount = captures.Count;
        var videoCount = videos.Count;
        var mediaCount = captureCount + videoCount;
        var summary = string.Join(" ", noteContents).Trim();

        if (string.IsNullOrWhiteSpace(summary))
        {
            summary = "No hay notas claras guardadas para este día.";
        }

        var normalized = summary.ToLowerInvariant();
        var sentenceCount = summary.Split(['.', '!', '?', '\n', ';'], StringSplitOptions.RemoveEmptyEntries).Count(part => part.Trim().Length > 12);
        var wordCount = summary.Split([' ', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries).Length;
        var hasImportantSystem = ContainsAny(normalized, ["cartas", "aguja", "abismo", "nexo", "clase", "clases", "enemigo", "enemigos", "combate", "sistema", "evento", "eventos", "exploración", "exploracion"]);
        var hasVisualHook = ContainsAny(normalized, ["limón", "limon", "gigante", "nube", "nubes", "visual", "color", "captura", "vídeo", "video", "escena", "zona"]);
        var hasSpoilerRisk = ContainsAny(normalized, ["spoiler", "secreto", "final", "lore importante", "revelación", "revelacion"]);

        string level;
        if (sentenceCount >= 3 || wordCount >= 80 || mediaCount >= 3)
        {
            level = "alto";
        }
        else if (sentenceCount >= 2 || wordCount >= 25 || mediaCount >= 1)
        {
            level = "medio";
        }
        else
        {
            level = "bajo";
        }

        string type;
        string reason;
        string missing;
        string possible;

        if ((noteContents.Count == 0 || wordCount < 6) && mediaCount == 0)
        {
            type = "no publicar todavía";
            reason = "No hay material suficiente para preparar una publicación honesta sin caer en relleno.";
            missing = "Notas concretas del avance, una captura clave y contexto mínimo sobre qué se trabajó.";
            possible = "Guardar una nota interna muy breve y completar el material antes de publicar.";
        }
        else if (hasSpoilerRisk)
        {
            type = "no publicar todavía";
            reason = "El material puede incluir spoilers o información delicada del lore.";
            missing = "Una versión segura sin spoilers y material visual que no revele contenido sensible.";
            possible = "Preparar una nota interna y decidir qué parte puede mostrarse públicamente.";
        }
        else if (sentenceCount >= 3 || wordCount >= 80 || mediaCount >= 3 || (hasImportantSystem && wordCount >= 45 && mediaCount >= 1))
        {
            type = "devlog completo";
            reason = "Hay suficiente información, contexto o material visual para sostener una entrada web sin forzar relleno.";
            missing = "Para reforzarlo, conviene añadir capturas principales, detalles concretos de cambios y estado de pruebas.";
            possible = "Entrada web completa, Discord, X, ideas de vídeo y recomendación de imagen principal.";
        }
        else if (mediaCount >= 1 && (hasVisualHook || wordCount < 45))
        {
            type = "idea para vídeo";
            reason = "El material tiene apoyo visual o puede transformarse mejor en pieza corta que en artículo largo.";
            missing = "Un texto breve que explique qué se ve y por qué importa dentro del desarrollo.";
            possible = "Idea de vídeo corto, post de apoyo para Discord o X y recomendación visual.";
        }
        else if (wordCount >= 18 && hasVisualHook && mediaCount == 0)
        {
            type = "solo redes";
            reason = "La nota tiene gancho o rareza, pero no hay material visual ni contexto suficiente para web.";
            missing = "Una captura o vídeo del elemento más llamativo y una explicación breve del contexto.";
            possible = "Post Discord, post X e idea TikTok opcional.";
        }
        else if (wordCount >= 18 || hasImportantSystem)
        {
            type = "avance corto";
            reason = "Hay una idea interesante, pero todavía no suficiente información para una entrada web larga.";
            missing = "Más detalles sobre qué cambió, estado del desarrollo y una imagen principal.";
            possible = "Mini update, Discord, X y una o dos ideas de vídeo si el tema lo permite.";
        }
        else
        {
            type = "nota interna";
            reason = "La nota es demasiado ambigua para publicar de forma clara.";
            missing = "Explicar qué se hizo realmente, por qué importa y qué material visual lo acompaña.";
            possible = "Resumen interno y lista de capturas o detalles que conviene preparar.";
        }

        return new EditorialDiagnostic(
            noteCount,
            captureCount,
            videoCount,
            summary,
            level,
            type,
            reason,
            missing,
            possible);
    }

    private static string BuildEditorialDiagnosticMarkdown(EditorialDiagnostic diagnostic)
    {
        return $"""
        # Diagnóstico editorial

        ## Material detectado

        - Cantidad de notas detectadas: {diagnostic.NoteCount}
        - Cantidad de capturas detectadas: {diagnostic.CaptureCount}
        - Cantidad de vídeos detectados: {diagnostic.VideoCount}

        ## Resumen real del material del día

        {diagnostic.Summary}

        ## Nivel de información

        {diagnostic.InformationLevel}

        ## Tipo de contenido recomendado

        {diagnostic.RecommendedType}

        ## Motivo de la recomendación

        {diagnostic.Reason}

        ## Qué falta para convertirlo en una entrada web fuerte

        {diagnostic.MissingForStrongWebEntry}

        ## Qué contenido sí se puede preparar hoy

        {diagnostic.PossibleContentToday}
        """.Trim() + Environment.NewLine;
    }

    private List<string> ReadNoteContents()
    {
        var notesFolder = Path.Combine(_dayPath, "Notas");
        if (!Directory.Exists(notesFolder))
        {
            return [];
        }

        return Directory.GetFiles(notesFolder)
            .Where(file => string.Equals(Path.GetExtension(file), ".md", StringComparison.OrdinalIgnoreCase) || string.Equals(Path.GetExtension(file), ".txt", StringComparison.OrdinalIgnoreCase))
            .OrderBy(Path.GetFileName)
            .Select(file => File.ReadAllText(file, Encoding.UTF8).Trim())
            .Where(content => !string.IsNullOrWhiteSpace(content))
            .ToList();
    }

    private static bool ContainsAny(string text, IEnumerable<string> options)
    {
        return options.Any(option => text.Contains(option, StringComparison.OrdinalIgnoreCase));
    }

    private void OpenEditorialDiagnostic()
    {
        EnsureDay(_currentDay);
        var output = Path.Combine(_dayPath, "Salida");
        Directory.CreateDirectory(output);

        var path = GetEditorialDiagnosticPath();
        if (!File.Exists(path))
        {
            var diagnostic = WriteEditorialDiagnostic(output);
            SetRecommendation(diagnostic.RecommendedType);
        }

        Process.Start(new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true
        });
    }

    private string GetEditorialDiagnosticPath()
    {
        return Path.Combine(_dayPath, "Salida", "diagnostico_editorial.md");
    }

    private void SetRecommendation(string recommendedType)
    {
        _recommendationLabel.Text = "Recomendación: " + ToTitle(recommendedType);
    }

    private static string ToTitle(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? "Pendiente" : char.ToUpperInvariant(value[0]) + value[1..];
    }

    private string ReadAllNotes()
    {
        var notesFolder = Path.Combine(_dayPath, "Notas");
        var files = Directory.Exists(notesFolder)
            ? Directory.GetFiles(notesFolder)
                .Where(file => string.Equals(Path.GetExtension(file), ".md", StringComparison.OrdinalIgnoreCase) || string.Equals(Path.GetExtension(file), ".txt", StringComparison.OrdinalIgnoreCase))
                .OrderBy(Path.GetFileName)
                .ToList()
            : [];

        if (files.Count == 0)
        {
            return "Todavía no hay notas guardadas. Añade una nota del día para que Aiko pueda redactar mejor.";
        }

        var builder = new StringBuilder();
        foreach (var file in files)
        {
            var content = File.ReadAllText(file, Encoding.UTF8).Trim();
            builder.AppendLine("### " + Path.GetFileName(file));
            builder.AppendLine(string.IsNullOrWhiteSpace(content) ? "Nota vacía." : content);
            builder.AppendLine();
        }

        return builder.ToString().Trim();
    }

    private string ReadExistingOutputFiles()
    {
        var output = Path.Combine(_dayPath, "Salida");
        if (!Directory.Exists(output))
        {
            return "No hay archivos generados todavía en Salida.";
        }

        var files = Directory.GetFiles(output, "*.md")
            .Where(file => !string.Equals(Path.GetFileName(file), "paquete_para_aiko.md", StringComparison.OrdinalIgnoreCase))
            .Where(file => !string.Equals(Path.GetFileName(file), "diagnostico_editorial.md", StringComparison.OrdinalIgnoreCase))
            .OrderBy(Path.GetFileName)
            .ToList();

        if (files.Count == 0)
        {
            return "No hay borradores base generados todavía.";
        }

        var builder = new StringBuilder();
        foreach (var file in files)
        {
            var content = File.ReadAllText(file, Encoding.UTF8).Trim();
            builder.AppendLine("### " + Path.GetFileName(file));
            builder.AppendLine(string.IsNullOrWhiteSpace(content) ? "Archivo vacío." : content);
            builder.AppendLine();
        }

        return builder.ToString().Trim();
    }

    private static string FormatFileList(List<string> files, string emptyMessage)
    {
        return files.Count == 0 ? "- " + emptyMessage : string.Join(Environment.NewLine, files.Select(file => "- " + file));
    }

    private void CopyAikoPackage()
    {
        var path = GetAikoPackagePath();
        if (!File.Exists(path))
        {
            GenerateAikoPackage();
            return;
        }

        TryCopyToClipboard(File.ReadAllText(path, Encoding.UTF8), "Paquete para Aiko copiado al portapapeles. Pega este paquete en ChatGPT/Aiko para obtener contenido mejor redactado.");
    }

    private void OpenAikoPackage()
    {
        var path = GetAikoPackagePath();
        if (!File.Exists(path))
        {
            GenerateAikoPackage();
        }

        Process.Start(new ProcessStartInfo
        {
            FileName = GetAikoPackagePath(),
            UseShellExecute = true
        });
    }

    private void SaveAikoResponse()
    {
        EnsureDay(_currentDay);

        var response = _aikoResponseBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(response) || response.StartsWith("Pega aquí", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show(this, "Pega primero la respuesta de ChatGPT/Aiko.", "Aiko Web News App", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var output = Path.Combine(_dayPath, "Salida");
        var drafts = Path.Combine(_dataRoot, "Borradores", _currentDay);
        Directory.CreateDirectory(output);
        Directory.CreateDirectory(drafts);

        File.WriteAllText(Path.Combine(output, "respuesta_aiko.md"), response + Environment.NewLine, Encoding.UTF8);
        File.WriteAllText(Path.Combine(drafts, "respuesta_aiko.md"), response + Environment.NewLine, Encoding.UTF8);
        SetStatus("Respuesta de Aiko guardada correctamente.");
    }

    private string GetAikoPackagePath()
    {
        return Path.Combine(_dayPath, "Salida", "paquete_para_aiko.md");
    }

    private void TryCopyToClipboard(string text, string successMessage)
    {
        try
        {
            Clipboard.SetText(text);
            SetStatus(successMessage);
        }
        catch (Exception ex)
        {
            Log(ex.ToString());
            SetStatus("No se pudo copiar al portapapeles. El archivo quedó guardado en Salida.");
        }
    }

    private void CopyDraftsToBorradores(string output)
    {
        var draftsFolder = Path.Combine(_dataRoot, "Borradores", _currentDay);
        Directory.CreateDirectory(draftsFolder);

        foreach (var file in Directory.GetFiles(output, "*.md"))
        {
            File.Copy(file, Path.Combine(draftsFolder, Path.GetFileName(file)), true);
        }

        File.WriteAllText(Path.Combine(draftsFolder, "borradores_generados.txt"), "Borradores generados: " + DateTime.Now + Environment.NewLine, Encoding.UTF8);
    }

    private void LoadPreviews()
    {
        _previewWeb.Text = ReadOutputOrPlaceholder("entrada_web.md");
        _previewDiscord.Text = ReadOutputOrPlaceholder("post_discord.md");
        _previewX.Text = ReadOutputOrPlaceholder("post_x.md");
    }

    private string ReadOutputOrPlaceholder(string fileName)
    {
        var path = Path.Combine(_dayPath, "Salida", fileName);
        return File.Exists(path) ? File.ReadAllText(path, Encoding.UTF8) : "Todavía no se ha generado este contenido.";
    }

    private static string ExtractHighlight(string notes)
    {
        var firstLine = notes.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
        return string.IsNullOrWhiteSpace(firstLine) ? "avances reales del desarrollo" : firstLine.Trim();
    }

    private string BuildWebEntry(string notes, List<string> captures, List<string> videos, string mainImage, string highlight)
    {
        return $"""
        # Título sugerido
        Devlog del {_currentDay}: {highlight}

        ## Subtítulo
        Un repaso honesto a los avances recientes de Caos Entre Reinos: Reborn.

        ## Resumen corto
        Hoy se organizaron notas y material del desarrollo. El foco está en mostrar progreso real sin prometer fechas ni presentar como terminado algo que todavía pueda estar en prueba.

        ## Texto tipo devlog
        Caos Entre Reinos: Reborn sigue avanzando paso a paso desde AikoGx Studios. La sesión del {_currentDay} deja una base útil para revisar el progreso del proyecto con tono cercano, indie y sin spoilers fuertes del lore.

        Notas del día:
        {AsMarkdownQuote(notes)}

        El juego mantiene su identidad action RPG chibi, low poly y fantasy caótico, con un mundo colorido, aventurero y sistemas como cartas, la Aguja del Caos, el Abismo, el Nexo, enemigos, clases y exploración.

        ## Qué se trabajó hoy
        - Punto principal: {highlight}
        - Estado: en desarrollo activo, con partes que pueden estar en prueba o ajuste.

        ## Qué material se ha añadido
        - Capturas: {(captures.Count == 0 ? "No se detectaron capturas" : captures.Count.ToString())}
        - Vídeos: {(videos.Count == 0 ? "No se detectaron vídeos" : videos.Count.ToString())}
        - Resumen: {BuildMaterialSummary(captures, videos)}

        ## Qué viene después
        Revisar los borradores, elegir el material visual más claro, publicar manualmente solo lo que esté listo para enseñar y seguir documentando avances reales del juego.

        ## Categoría recomendada
        Devlog / Desarrollo indie

        ## Tags sugeridos
        Caos Entre Reinos Reborn, AikoGx Studios, devlog, action RPG, indie game, low poly, fantasy, desarrollo de videojuegos

        ## Imagen recomendada
        {mainImage}
        """;
    }

    private static string BuildDiscordPost(string highlight)
    {
        return $"""
        Hoy Caos Entre Reinos: Reborn sigue avanzando con trabajo centrado en {highlight}.

        Todavía hay cosas en prueba y ajuste, pero el proyecto va cogiendo forma poco a poco. La idea es enseñar avances reales, sin spoilers fuertes y sin vender nada como terminado antes de tiempo.

        Gracias por seguir acompañando el desarrollo.
        """;
    }

    private static string BuildXPost(string highlight)
    {
        return $"""
        Nuevo avance de Caos Entre Reinos: Reborn: {highlight}.

        Seguimos puliendo este action RPG chibi/low poly con fantasía caótica, cartas, exploración y desarrollo indie paso a paso.

        #IndieDev #GameDev #Devlog
        """;
    }

    private static string BuildTikTokIdeas(List<string> captures, List<string> videos, string highlight)
    {
        var visual = videos.FirstOrDefault() ?? captures.FirstOrDefault() ?? "No se detectaron vídeos ni capturas; importar material antes de publicar.";
        return $"""
        # Ideas para TikTok

        ## 1. Avance rápido del día
        - Título: Así avanza Caos Entre Reinos: Reborn
        - Gancho inicial: "Hoy tocó probar una parte nueva del caos."
        - Qué mostrar: {visual}
        - Texto en pantalla: "Desarrollo indie en progreso: {highlight}"
        - Duración aproximada: 12-18 segundos
        - Tono/música recomendada: Energía aventurera, curiosa y ligera.

        ## 2. Antes de publicar, revisar
        - Título: Lo que todavía está en prueba
        - Gancho inicial: "No todo está terminado, pero esto ya empieza a tomar forma."
        - Qué mostrar: Capturas del día y cortes breves de gameplay si existen.
        - Texto en pantalla: "En prueba. En ajuste. En desarrollo."
        - Duración aproximada: 15-22 segundos
        - Tono/música recomendada: Cercano, honesto, con ritmo suave.

        ## 3. Un detalle del mundo
        - Título: Un vistazo sin spoilers
        - Gancho inicial: "Pequeño vistazo al mundo sin destripar el lore."
        - Qué mostrar: Imagen principal recomendada o zona visualmente más clara.
        - Texto en pantalla: "Fantasía caótica, chibi y low poly"
        - Duración aproximada: 10-15 segundos
        - Tono/música recomendada: Fantasía colorida, misteriosa pero amable.
        """;
    }

    private static string BuildShortsIdeas(List<string> captures, List<string> videos, string highlight)
    {
        var material = videos.Count > 0 ? "vídeo del día" : captures.Count > 0 ? "capturas del día" : "No se detectaron vídeos ni capturas todavía";
        return $"""
        # Ideas para YouTube Shorts

        ## 1. Devlog compacto
        - Título: Caos Entre Reinos: Reborn sigue creciendo
        - Gancho: "Un avance pequeño, pero real, del desarrollo."
        - Estructura del vídeo: Abrir con el plano más claro, enseñar {material}, cerrar con una frase de progreso.
        - Texto sugerido: "Hoy el foco fue: {highlight}. Sigue en desarrollo, pero cada prueba ayuda a darle forma."

        ## 2. Material del día
        - Título: Qué se puede enseñar hoy
        - Gancho: "Esto es lo más interesante que dejó la sesión."
        - Estructura del vídeo: Mostrar 2 o 3 planos, evitar spoilers fuertes, terminar con el nombre del juego.
        - Texto sugerido: "Caos Entre Reinos: Reborn, action RPG chibi/low poly en desarrollo por AikoGx Studios."
        """;
    }

    private static string BuildDailySummary(string notes, List<string> captures, List<string> videos, string highlight)
    {
        return $"""
        # Resumen del día

        ## Qué se trabajó
        {notes}

        ## Qué material hay disponible
        - Capturas: {(captures.Count == 0 ? "No se detectaron capturas" : captures.Count.ToString())}
        - Vídeos: {(videos.Count == 0 ? "No se detectaron vídeos" : videos.Count.ToString())}

        ## Qué parece más interesante
        {highlight}

        ## Qué debería publicarse primero
        Revisar primero la entrada web si hay suficientes notas. Si hay una captura clara, usarla como apoyo visual principal. Si hay vídeo, priorizar Shorts o TikTok con un enfoque breve y honesto.
        """;
    }

    private static string BuildRecommendedImages(List<string> captures, string mainImage)
    {
        var list = captures.Count == 0 ? "- No se detectaron capturas." : string.Join(Environment.NewLine, captures.Select(x => "- " + x));
        var secondary = captures.Count <= 1 ? "- No hay suficientes capturas secundarias." : string.Join(Environment.NewLine, captures.Skip(1).Take(4).Select(x => "- " + x));
        return $"""
        # Imágenes recomendadas

        ## Capturas detectadas
        {list}

        ## Imagen principal recomendada
        {mainImage}

        ## Imágenes secundarias recomendadas
        {secondary}

        Nota: no se ha editado ninguna imagen. Este archivo solo recomienda qué revisar o usar manualmente.
        """;
    }

    private static string BuildMaterialSummary(List<string> captures, List<string> videos)
    {
        return string.Join(", ",
        [
            captures.Count == 0 ? "No se detectaron capturas" : $"{captures.Count} captura(s)",
            videos.Count == 0 ? "No se detectaron vídeos" : $"{videos.Count} vídeo(s)"
        ]);
    }

    private static string AsMarkdownQuote(string text)
    {
        return string.Join(Environment.NewLine, text.Split(["\r\n", "\n"], StringSplitOptions.None).Select(line => "> " + line));
    }

    private static void Write(string folder, string fileName, string content)
    {
        File.WriteAllText(Path.Combine(folder, fileName), content.Trim() + Environment.NewLine, Encoding.UTF8);
    }

    private void CopyOutput(string fileName)
    {
        var path = Path.Combine(_dayPath, "Salida", fileName);
        if (!File.Exists(path))
        {
            PrepareContent();
        }

        try
        {
            Clipboard.SetText(File.ReadAllText(path, Encoding.UTF8));
            SetStatus(fileName + " copiado al portapapeles.");
        }
        catch (Exception ex)
        {
            Log(ex.ToString());
            SetStatus("No se pudo copiar al portapapeles.");
            MessageBox.Show(this, "No se pudo copiar al portapapeles. El archivo sigue guardado en la carpeta Salida.", "Aiko Web News App", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void MarkAsPublished()
    {
        var publishedFolder = Path.Combine(_dataRoot, "Publicados", _currentDay);
        Directory.CreateDirectory(publishedFolder);
        File.WriteAllText(Path.Combine(publishedFolder, "publicado.txt"), "Marcado como publicado manualmente el " + DateTime.Now + Environment.NewLine, Encoding.UTF8);

        var salida = Path.Combine(_dayPath, "Salida");
        if (Directory.Exists(salida))
        {
            foreach (var file in Directory.GetFiles(salida, "*.md"))
            {
                File.Copy(file, Path.Combine(publishedFolder, Path.GetFileName(file)), true);
            }
        }

        SetStatus("Publicado marcado correctamente.");
    }

    private static void OpenFolder(string folder)
    {
        Directory.CreateDirectory(folder);
        Process.Start(new ProcessStartInfo
        {
            FileName = folder,
            UseShellExecute = true
        });
    }

    private void SetStatus(string message)
    {
        _statusLabel.Text = DateTime.Now.ToString("HH:mm:ss") + "  " + message;
    }

    private void Log(string message)
    {
        Directory.CreateDirectory(Path.Combine(_dataRoot, "Logs"));
        File.AppendAllText(Path.Combine(_dataRoot, "Logs", "app.log"), DateTime.Now + Environment.NewLine + message + Environment.NewLine + Environment.NewLine, Encoding.UTF8);
    }
}
