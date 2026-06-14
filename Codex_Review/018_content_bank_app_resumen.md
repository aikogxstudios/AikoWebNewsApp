# 018 - Content Bank en Aiko Web News App

## Tarea realizada

Se ejecuto la issue #7 y la tarea `Aiko_To_Codex/018_content_bank_app.md`.

Tambien se reviso la issue #6 de privacidad para usar solo `Fak` como nombre visible en documentacion publica, tareas y resumenes versionados.

## Archivos modificados

- `Form1.cs`
- `README.md`
- `AGENTS.md`
- `Aiko_Memory/AIKO_HANDOFF_2026-06-14.md`
- `Aiko_To_Codex/*.md`
- `Codex_Done/README.md`
- `Codex_Review/014_organizador_notas_desarrollador_resumen.md`
- `Codex_Review/018_content_bank_app_resumen.md`

## Cambios principales

- Nuevo boton: `Generar ideas Content Bank`.
- Nuevo boton: `Abrir Content Bank`.
- Nueva salida local: `Dias/YYYY-MM-DD/Salida/ContentBank/`.
- Generacion de:
  - `paquete_para_contentbank.md`
  - `ideas_tiktok_shorts.md`
  - `esta_semana.md`
  - `necesitan_clip.md`
  - `necesitan_captura.md`
  - `reciclables.md`
  - `publicaciones_realizadas_template.md`
- Las ideas incompletas se marcan con `Estado: Necesita contexto`.
- El paquete indica que no publica automaticamente, no conecta con GitHub y no modifica WordPress.
- La documentacion visible usa `Fak` como nombre publico.
- Se revisaron y actualizaron comentarios visibles de la issue #5 para mantener `Fak` como nombre publico.

## Pruebas realizadas

- `dotnet build -c Release`
- Prueba temporal automatizada con una nota simple del dia.
- Resultado: `CONTENT_BANK_TEST_OK`.
- Escaneo de privacidad en Markdown versionado:
  - no quedan nombres personales antiguos visibles
  - no queda formato mixto de nombre publico
  - no se detecto mojibake

## Problemas encontrados

- Durante la limpieza inicial de nombres, algunos Markdown quedaron temporalmente con mojibake por codificacion. Se corrigio antes de cerrar la tarea.

## Pendientes o recomendaciones

- Probar manualmente el boton en la app publicada.
- En una tarea futura, se puede añadir una pestaña de vista previa Content Bank si Fak la quiere.
- Mantener el flujo como copia manual hacia `AikoGx-ContentBank`; la app no debe conectar con GitHub sin aprobacion explicita.
