# 020 - Simplificar UX del dashboard

## Tarea realizada

Se ejecuto la issue #9: simplificar la experiencia del dashboard para que Fak entienda el flujo principal en segundos.

## Archivos modificados

- `Form1.cs`
- `Codex_Review/020_simplificar_ux_dashboard_resumen.md`

## Cambios principales

- La pantalla principal ahora esta dominada por el bloque `Pegar paquete para Aiko`.
- Se añadio un textarea principal para pegar el paquete completo del dia.
- Se añadio el boton principal grande `Analizar con Aiko`.
- Se añadieron acciones principales claras:
  - `Analizar con Aiko`
  - `Copiar resultado`
  - `Abrir carpeta del dia`
- Se añadio el boton `Pegar paquete completo`.
- El flujo visual ahora es:
  - `Pegar`
  - `Analizar`
  - `Revisar`
  - `Copiar`
- Las acciones menos importantes se movieron a `Herramientas avanzadas`.
- Se renombraron botones visibles a textos mas humanos:
  - `Nuevo dia`
  - `Generar paquete base`
  - `Banco de ideas`
  - `Escribir manualmente`
  - `Marcar como publicado`
  - `Abrir resultado`
  - `Copiar devlog web`
- La vista de diagnostico principal ahora muestra:
  - resumen del dia
  - material detectado
  - recomendacion
  - motivo
  - que falta antes de publicar
- Se mantiene el Markdown tecnico en archivos, pero la UI muestra una version mas limpia.

## Funciones preservadas

- Guardado local de notas.
- Organizador de notas.
- Diagnostico editorial.
- Paquete para Aiko.
- Respuesta de Aiko.
- Content Bank local.
- Borrador WordPress seguro.
- Fallback manual de WordPress.

## WordPress

No se modifico la seguridad de WordPress.

Se mantiene:

- nada se publica automaticamente
- `WordPressDraftStatus = "draft"`
- borradores manuales cuando no procede API

## Pruebas realizadas

- `dotnet build -c Release`
- `dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64`
- Prueba temporal automatizada:
  - verifica el bloque `Pegar paquete para Aiko`
  - verifica `Analizar con Aiko`
  - verifica `Copiar resultado`
  - verifica `Abrir carpeta del dia`
  - verifica `Herramientas avanzadas`
  - verifica flujo `Pegar / Analizar / Revisar / Copiar`
  - analiza un paquete de prueba
  - confirma que se genera diagnostico editorial
  - confirma que WordPress sigue en `draft`

Resultado:

`UX_SIMPLIFICATION_TEST_OK`

## Problemas encontrados

- El primer publish fallo porque habia una instancia abierta de la app bloqueando archivos en `publish\win-x64`. Se cerro el proceso y el publish final funciono.
- Un test temporal buscaba coincidencias exactas de textos de botones; se ajusto para validar texto contenido porque la UI muestra pasos como `1. Pegar`.

## Resultado final

Exe actualizado:

`publish\win-x64\AikoWebNewsApp.exe`

## Pendientes o recomendaciones

- Probar manualmente con un paquete real de devlog.
- Si esta UX queda aprobada, limpiar en una tarea futura las UIs antiguas no usadas para reducir codigo.
