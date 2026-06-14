# 021 - Correccion UX funcional y guia

Fecha: 2026-06-14

## Tarea realizada

Se ejecuto la issue #10 / tarea `Aiko_To_Codex/021_correccion_ux_funcional_y_guia.md`.

## Archivos modificados

- `Form1.cs`
- `Codex_Review/021_correccion_ux_funcional_y_guia_resumen.md`

## Cambios principales

- La app conserva apertura maximizada y el dashboard principal queda con scroll en zonas largas.
- La sidebar ahora tiene scroll para evitar opciones inaccesibles.
- Se elimino el chip falso de `Modo oscuro`.
- Los botones del header ahora tienen accion real:
  - `Avisos`: muestra estado sin avisos.
  - `Ayuda`: abre una guia interna.
  - `Ajustes`: abre la carpeta `Config`.
- El flujo diario se compacto para que los 5 pasos no queden cortados.
- Se agrego el texto inicial: `Empieza aqui: pega tus notas del dia y pulsa Analizar con Aiko.`
- `Progreso semanal` ya no usa grafico confuso y muestra `0/2 videos esta semana`.
- `Distribucion de contenido` ya no muestra porcentajes inventados; ahora indica `Sin datos suficientes`.
- `Material util` muestra contadores y boton `Abrir carpeta de material`.
- La recomendacion de Aiko se limpio para evitar caracteres corruptos y mantener motivo, siguiente paso y accion.
- `Acciones rapidas` mantiene scroll interno.
- `Tareas para hoy` usa checklist con prioridades.
- El diagnostico se mantiene formateado con titulos y separadores.

## Botones funcionales revisados

- `Avisos`
- `Ayuda`
- `Ajustes`
- `Pegar paquete completo`
- `Analizar con Aiko`
- `Copiar resultado`
- `Abrir carpeta del dia`
- `Abrir carpeta de material`
- Acciones de sidebar con estado o accion real local.

## Botones pendientes

- `Calendario`: marcado como pendiente, sin automatizaciones.
- `itch.io`: marcado como preparacion manual desde borradores.
- `Estado del Proyecto`: mantiene estado informativo, sin pantalla dedicada todavia.

## Guia de uso

Se accede desde el boton `Ayuda` del header. La guia explica el flujo:

1. Escribir o pegar notas.
2. Importar capturas o videos.
3. Analizar con Aiko.
4. Revisar recomendacion.
5. Completar contexto si falta.
6. Generar paquete para Aiko o Content Bank.
7. Revisar resultados.
8. Copiar manualmente o crear borrador WordPress en draft.

## Pruebas realizadas

- `dotnet build -c Release`
- Prueba temporal WinForms por reflexion:
  - verifica ventana maximizada;
  - verifica boton `Ayuda`;
  - verifica texto inicial;
  - verifica `0/2 videos esta semana`;
  - verifica `Sin datos suficientes`;
  - verifica boton de material;
  - verifica checklist con `CheckBox`;
  - ejecuta `Analizar con Aiko`;
  - confirma `diagnostico_editorial.md`;
  - confirma diagnostico legible con separadores;
  - confirma `WordPressDraftStatus = draft`.
- `dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64`

## Problemas encontrados

- Habia textos visibles con caracteres corruptos por codificacion. Se corrigieron los que afectaban al dashboard activo y a la logica de recomendacion.
- WinForms limita bastante el estilo de `TabControl`; se mantuvo funcional, oscuro en el contenido y con texto legible.

## Pendientes o recomendaciones

- En una siguiente tarea conviene reemplazar el `TabControl` clasico por pills/botones propios si se quiere pulido visual completo.
- La distribucion de contenido debe conectarse a historial real antes de mostrar porcentajes.
- El progreso semanal puede calcularse desde historial cuando exista una fuente estable.
