# 022 - Sidebar con navegacion real

Fecha: 2026-06-14

## Tarea realizada

Se ejecuto la issue #11 / tarea `Aiko_To_Codex/022_sidebar_navegacion_real.md`.

## Archivos modificados

- `Form1.cs`
- `Codex_Review/022_sidebar_navegacion_real_resumen.md`

## Cambios principales

- La sidebar dejo de ser solo decorativa y ahora cambia el panel central.
- Se agrego un host central de contenido para renderizar secciones.
- Se marca visualmente la seccion activa en la sidebar.
- La sidebar mantiene scroll para evitar opciones inaccesibles.
- Se agregaron pantallas funcionales para:
  - `Inicio`
  - `Notas del Dia`
  - `Ideas / Content Bank`
  - `Tareas`
  - `Archivos y Material`
  - `Estado del Proyecto`
  - `Ajustes`
- Se agrego panel `Pendiente` claro para:
  - `Devlogs`
  - `Discord`
  - `X (Twitter)`
  - `TikTok / Shorts`
  - `itch.io`
  - `Calendario`
- Se protegieron los refrescos de previews/material para que no fallen al navegar a vistas sin esos controles.

## Comportamiento de la sidebar

- `Inicio`: muestra el dashboard resumen.
- `Notas del Dia`: muestra paquete, analisis con Aiko y previews/resultados.
- `Ideas / Content Bank`: muestra acciones de Content Bank y previsualiza `esta_semana.md` si existe.
- `Tareas`: muestra checklist con prioridad y accesos rapidos.
- `Archivos y Material`: muestra contadores/lista de capturas y videos, con botones para abrir carpetas.
- `Estado del Proyecto`: muestra estado editorial, WordPress draft seguro y objetivo semanal.
- `Ajustes`: muestra configuracion local y botones para abrir `Config`, `Plantillas` y `Logs`.

## Pruebas realizadas

- `dotnet build -c Release`
- Prueba temporal WinForms:
  - instancio `Form1`;
  - pulso todas las entradas de la sidebar por reflexion;
  - confirmo que cada una renderiza un panel central;
  - confirmo que las secciones no implementadas muestran `Pendiente`;
  - confirmo que se registran los botones de sidebar.
- Resultado de prueba temporal: `SIDEBAR_NAVIGATION_TEST_OK`
- `dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64`

## Problemas encontrados

- La carpeta temporal de prueba quedo bloqueada por procesos de build. Se resolvio apagando servidores de build con `dotnet build-server shutdown` y se elimino correctamente.

## Pendientes o recomendaciones

- Crear pantallas completas especificas para Devlogs, Discord, X, TikTok/Shorts, itch.io y Calendario cuando el flujo este definido.
- Conectar la vista `Estado del Proyecto` a historial real cuando existan datos estables.
- Mantener WordPress siempre en `draft`; no se modifico la seguridad de WordPress.
