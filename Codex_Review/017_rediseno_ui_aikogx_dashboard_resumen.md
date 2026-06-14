# 017 - Rediseño UI AikoGx Dashboard

## Tarea realizada

Se ejecuto la issue #5 y la tarea `Aiko_To_Codex/017_rediseno_ui_aikogx_dashboard.md`.

El objetivo fue estabilizar la interfaz principal como dashboard editorial interno de AikoGx Studios antes de avanzar con nuevas funciones.

## Archivos modificados

- `Form1.cs`
- `README.md`
- `Codex_Review/017_rediseno_ui_aikogx_dashboard_resumen.md`

## Cambios visuales principales

- Nueva interfaz principal tipo dashboard oscuro AikoGx.
- Header con:
  - `Aiko Web News App`
  - subtitulo de dashboard editorial interno
  - proyecto activo
  - aviso de modo seguro WordPress en borrador
- Columna izquierda centrada en `Notas del dia`.
- Cards de estado para:
  - Notas
  - Capturas
  - Videos
  - Diagnostico
  - Paquete Aiko
  - Respuesta
  - WordPress
- Seccion visible `Estado de publicacion`.
- Flujo principal por pasos:
  1. Crear/Cargar dia
  2. Importar capturas
  3. Organizar notas
  4. Analizar material
  5. Paquete para Aiko
  6. Guardar respuesta
  7. Borrador WordPress
- `Preparar contenido base` queda como herramienta secundaria.
- Tabs reorganizadas:
  - Diagnostico
  - Notas organizadas
  - Respuesta de Aiko
  - Web
  - Redes
  - WordPress
  - Material

## Funciones existentes preservadas

- Guardar nota rapida.
- Abrir carpeta del dia.
- Abrir salida.
- Importar capturas y videos.
- Organizar notas.
- Analizar material.
- Generar paquete para Aiko.
- Guardar respuesta de Aiko.
- Preparar contenido base.
- Crear borrador WordPress.
- Abrir borrador manual.
- Marcar como publicado.
- Generar ideas Content Bank queda visible como herramienta secundaria, sin ejecutarse como flujo principal.

## WordPress

No se modifico la seguridad de WordPress.

Se mantiene:

- constante `WordPressDraftStatus = "draft"`
- envio REST con `status = draft`
- bloqueo si `defaultStatus` no es `draft`
- fallback manual
- cero publicacion automatica

## Pruebas realizadas

- `dotnet build -c Release`
- `dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64`
- Prueba temporal automatizada del dashboard:
  - abre `Form1`
  - verifica textos principales del dashboard
  - guarda nota de prueba
  - organiza notas
  - analiza material
  - genera paquete para Aiko
  - guarda respuesta de Aiko
  - genera borrador manual WordPress
  - confirma `WordPressDraftStatus == "draft"`

Resultado de prueba:

`DASHBOARD_UI_TEST_OK`

## Resultado de build

Build correcto, 0 errores.

## Resultado de publish

Publish correcto.

Exe actualizado:

`publish\win-x64\AikoWebNewsApp.exe`

## Problemas encontrados

- El archivo tiene textos antiguos con acentos y la consola de PowerShell los muestra con mojibake, pero el proyecto compila correctamente.
- Para evitar riesgo, se añadio `BuildDashboardUi()` nuevo y se dejo `BuildUi()` antiguo sin usar como referencia.

## Pendientes o mejoras futuras

- Probar visualmente el exe publicado en Windows con distintos tamaños de ventana.
- Ajustar responsive fino si algun boton queda apretado en pantallas pequeñas.
- En una tarea posterior, se puede retirar `BuildUi()` antiguo cuando Fak confirme que el dashboard nuevo queda aprobado.
