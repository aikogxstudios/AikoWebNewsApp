# 026 - Añadir iconos FontAwesome a sidebar y botones principales

Estado: lista para Codex
Fecha: 2026-06-15

## Contexto

La tarea 025 ya verifico que los paquetes UI WinForms estan instalados y que la app compila/publica correctamente.

Paquete que se debe usar en esta tarea:

- `FontAwesome.Sharp`

Paquetes que NO se deben usar todavia en esta tarea:

- `Krypton.Toolkit`
- `ReaLTaiizor`

Esta tarea es una mejora visual pequena y segura. No debe tocar logica principal.

## Objetivo

Mejorar la claridad visual de la app usando iconos FontAwesome en:

1. Sidebar / menu lateral.
2. Botones principales de las paginas.
3. Boton principal de la card `Siguiente paso recomendado` si aplica.

La app debe seguir siendo WinForms .NET 8.

## Trabajo solicitado

### 1. Sidebar con iconos

Actualizar los botones del menu lateral para que tengan icono + texto.

Usar `FontAwesome.Sharp.IconButton` o un enfoque equivalente con `IconChar`.

Iconos sugeridos:

- Inicio: `House` o `Home`
- Notas del Dia: `PenToSquare`, `Pen`, `Edit` o similar
- Devlogs: `Newspaper`
- Discord: `Comments` o `Message`
- X: `Bullhorn`, `ShareNodes` o similar
- TikTok/Shorts: `Video`
- itch.io: `Gamepad`
- Ideas / Content Bank: `Lightbulb`
- Tareas: `ListCheck` o `CheckSquare`
- Calendario: `CalendarDays`
- Archivos y Material: `FolderOpen`
- Estado del Proyecto: `ChartLine`
- Ajustes: `Gear`

Si algun icono exacto no existe en la version instalada, usar el mas parecido.

### 2. Estilo de sidebar

Mantener estilo oscuro AikoGx:

- fondo oscuro;
- texto claro;
- iconos en gris/lila suave;
- estado activo con borde o fondo morado/magenta sutil;
- hover discreto si ya existe infraestructura para ello.

No crear animaciones complejas.

### 3. Botones principales

Agregar iconos a botones importantes sin cambiar su funcionamiento:

- `Analizar con Aiko`: icono tipo `WandMagicSparkles`, `Brain`, `Robot` o similar.
- `Generar paquete para Aiko`: icono tipo `BoxArchive`, `FileExport`, `PaperPlane` o similar.
- `Generar Content Bank`: icono `Lightbulb` o `FolderPlus`.
- `Crear borrador draft`: icono `FilePen` o `FileLines`.
- `Abrir carpeta Salida`: icono `FolderOpen`.
- `Ayuda`: icono `CircleQuestion`.
- `Ajustes`: icono `Gear`.

Si un boton es de tipo normal `Button`, se puede reemplazar por `IconButton` solo si no rompe layout ni eventos.

### 4. No romper navegacion

La navegacion de sidebar implementada en tareas anteriores debe seguir funcionando.

Cada boton debe seguir abriendo su seccion correspondiente o panel pendiente.

## Reglas importantes

- No tocar WordPress salvo que sea necesario para compilar.
- No cambiar seguridad de WordPress: siempre draft.
- No publicar automaticamente.
- No conectar GitHub desde la app.
- No migrar a WPF/WinUI.
- No usar Krypton ni ReaLTaiizor todavia.
- No rehacer toda la UI.
- No cambiar textos publicos a nombres reales. Usar solo `Fak` si aparece nombre visible.
- Evitar meter cambios grandes fuera de sidebar y botones principales.

## Validacion

Ejecutar:

```text
dotnet restore
dotnet build -c Release
dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64
```

Validar manualmente o mediante prueba temporal:

- La app abre.
- Sidebar muestra iconos.
- La navegacion lateral sigue funcionando.
- El boton activo sigue siendo reconocible.
- No hay botones cortados por culpa de los iconos.
- La card `Siguiente paso recomendado` sigue funcionando.

## Entrega

Crear resumen en:

```text
Codex_Review/026_fontawesome_sidebar_botones_resumen.md
```

El resumen debe indicar:

- archivos modificados;
- iconos aplicados;
- si algun icono fue sustituido por alternativa;
- resultado de restore/build/publish;
- si hay warnings;
- commit final.
