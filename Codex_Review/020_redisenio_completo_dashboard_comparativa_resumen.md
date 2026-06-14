# 020 - Rediseño completo dashboard desde comparativa

## Tarea realizada

Se ejecuto la issue #9 / tarea `Aiko_To_Codex/020_redisenio_completo_dashboard_comparativa.md`.

El objetivo fue rehacer la pantalla Inicio como dashboard general y no solo como pantalla para pegar texto.

## Archivos modificados

- `Form1.cs`
- `Codex_Review/020_redisenio_completo_dashboard_comparativa_resumen.md`

## Que se corrigio funcionalmente

- La app abre maximizada.
- Se añadio `MinimumSize` para evitar una ventana demasiado pequeña.
- La pantalla principal usa un panel con scroll vertical.
- Se redujo el riesgo de botones cortados moviendo bloques largos a cards con scroll.
- Los botones visibles tienen accion real o muestran estado pendiente.
- El footer muestra estado seguro, proyecto, hora y version.
- Se mantuvo el flujo de:
  - guardar nota
  - organizar notas
  - analizar con Aiko
  - generar paquete Aiko
  - generar Content Bank
  - guardar respuesta
  - crear borrador manual WordPress

## Que se cambio visualmente

- Nueva composicion `BuildCompleteDashboardUi()`.
- Sidebar completa con:
  - Inicio
  - Notas del Dia
  - Devlogs
  - Discord
  - X (Twitter)
  - TikTok / Shorts
  - itch.io
  - Ideas / Content Bank
  - Tareas
  - Calendario
  - Archivos y Material
  - Estado del Proyecto
  - Ajustes
- Tarjeta `Proyecto actual`.
- Header compacto:
  - `Hola, Fak`
  - `Centro de mando editorial de AikoGx`
  - fecha y frase motivacional
  - botones visuales de notificaciones, ayuda, ajustes y modo oscuro
- Dashboard de inicio con:
  - flujo de trabajo diario de 5 pasos
  - estado de hoy
  - progreso semanal
  - distribucion de contenido
  - material util
  - ultimos elementos
  - recomendacion de Aiko destacada
  - acciones rapidas
  - tareas para hoy
  - pegar paquete para Aiko
  - previews inferiores

## Botones pendientes

- Sidebar: algunas secciones son todavia accesos visuales y muestran mensaje de pendiente porque no existen pantallas internas para cada modulo.
- Header: notificaciones, ayuda y ajustes muestran mensajes locales; no abren pantallas completas todavia.
- `Ver detalles del proyecto` muestra estado pendiente porque no existe vista de proyecto completa.

No se dejaron como automatizaciones falsas ni conectan con servicios externos.

## WordPress

No se modifico la seguridad de WordPress.

Se mantiene:

- `WordPressDraftStatus = "draft"`
- borrador REST siempre draft
- fallback manual
- nada se publica automaticamente

## Pruebas realizadas

- `dotnet build -c Release`
- `dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64`
- Prueba temporal automatizada:
  - verifica que la app abre maximizada
  - verifica header, sidebar, proyecto actual, flujo, estado de hoy, progreso semanal, distribucion, ultimos elementos, acciones y tareas
  - analiza un paquete de prueba
  - genera paquete Aiko
  - genera Content Bank
  - guarda respuesta de Aiko
  - crea borrador manual WordPress
  - confirma WordPress en `draft`

Resultado:

`COMPLETE_DASHBOARD_TEST_OK`

## Resultado de build

Build correcto, 0 advertencias y 0 errores.

## Resultado de publish

Publish correcto.

Exe actualizado:

`publish\win-x64\AikoWebNewsApp.exe`

## Limitaciones de WinForms

- El `TabControl` nativo sigue teniendo limitaciones visuales para un tema oscuro completo.
- El dashboard usa cards y scroll para evitar contenido cortado, pero un ajuste visual perfecto en tamaños pequeños requeriria otra tarea especifica.
- Se mantienen versiones anteriores de UI en codigo como referencia; se pueden limpiar cuando Fak apruebe definitivamente esta direccion.

## Pendientes recomendados

- Probar visualmente el exe publicado en monitor real.
- Revisar si la sidebar debe navegar a pantallas internas reales.
- Crear una tarea futura para limpiar metodos UI antiguos no usados.
