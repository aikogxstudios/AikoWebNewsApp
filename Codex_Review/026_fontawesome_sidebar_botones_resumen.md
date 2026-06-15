# 026 - FontAwesome sidebar botones

Fecha: 2026-06-15

## Tarea realizada

Se ejecuto `Aiko_To_Codex/026_fontawesome_sidebar_botones.md`.

## Archivos modificados

- `Form1.cs`
- `Codex_Review/026_fontawesome_sidebar_botones_resumen.md`

## Cambios principales

- Se agrego `FontAwesome.Sharp` en `Form1.cs`.
- Se actualizo el helper `MakeButton` para crear `IconButton` cuando el texto del boton tiene icono asignado.
- La sidebar usa icono + texto sin cambiar la navegacion.
- El estado activo de la sidebar tambien cambia el color del icono.
- Se agregaron iconos a botones principales como:
  - `Analizar con Aiko`
  - `Generar paquete para Aiko`
  - `Generar Content Bank`
  - `Crear borrador draft`
  - `Abrir carpeta Salida`
  - `Ayuda`
  - `Ajustes`
- La card `Siguiente paso recomendado` conserva su logica y actualiza el icono del boton principal cuando cambia el paso.

## Iconos aplicados

- `Inicio`: `House`
- `Notas del Dia`: `PenToSquare`
- `Devlogs`: `Newspaper`
- `Discord`: `Comments`
- `X (Twitter)`: `ShareNodes`
- `TikTok / Shorts`: `Video`
- `itch.io`: `Gamepad`
- `Ideas / Content Bank`: `Lightbulb`
- `Tareas`: `ListCheck`
- `Calendario`: `CalendarDays`
- `Archivos y Material`: `FolderOpen`
- `Estado del Proyecto`: `ChartLine`
- `Ajustes`: `Gear`
- `Ayuda`: `CircleQuestion`
- `Avisos`: `Bell`

## Sustituciones

- Para `X (Twitter)` se uso `ShareNodes` como alternativa visual general.
- Para acciones de Aiko se uso `WandMagicSparkles`.
- Para paquete Aiko se uso `BoxArchive`.

## Pruebas realizadas

- Prueba temporal WinForms:
  - verifica que todos los botones de sidebar son `IconButton`;
  - verifica que todos tienen `IconChar`;
  - prueba la navegacion de cada item de sidebar;
  - verifica que `Ayuda` tiene icono;
  - verifica que el boton principal de `Siguiente paso recomendado` tiene icono.
- Resultado: `FONTAWESOME_SIDEBAR_TEST_OK`
- `dotnet restore`
- `dotnet build -c Release`
  - Warnings: `0`
  - Errores: `0`
- `dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64`

## Reglas respetadas

- No se uso `Krypton.Toolkit`.
- No se uso `ReaLTaiizor`.
- No se cambio la logica de WordPress.
- WordPress sigue siendo `draft`.
- No se agrego publicacion automatica.
- No se conecto GitHub desde la app.
- No se migro a WPF/WinUI.

## Pendientes o recomendaciones

- Si se quiere afinar mas, la siguiente tarea podria ajustar tamanos/espaciado de iconos tras revision visual de Fak.
