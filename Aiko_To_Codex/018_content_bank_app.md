# 018 - Content Bank en Aiko Web News App

Estado: lista para Codex
Fecha: 2026-06-14

## Objetivo

Añadir a la app una accion para generar ideas de contenido destinadas al repo `AikoGx-ContentBank`.

La app debe transformar notas del dia, capturas y videos en ideas para:

- TikTok
- YouTube Shorts
- Discord
- X
- web/devlogs
- itch.io

## Regla de nombre publico

Usar siempre **Fak** como nombre visible en textos, ejemplos y archivos generados.

## Flujo deseado

1. Se escriben notas del dia.
2. La app organiza notas y analiza material.
3. Nueva accion: **Generar ideas Content Bank**.
4. La app crea archivos locales para revisar.
5. El equipo copia manualmente las ideas utiles al repo `AikoGx-ContentBank`.

## Carpeta de salida

Crear:

```text
Dias/YYYY-MM-DD/Salida/ContentBank/
```

Generar dentro:

```text
paquete_para_contentbank.md
ideas_tiktok_shorts.md
esta_semana.md
necesitan_clip.md
necesitan_captura.md
reciclables.md
publicaciones_realizadas_template.md
```

## Criterio editorial

No publicar automaticamente.

No conectar con GitHub desde la app.

No prometer fechas.

No convertir notas confusas en anuncios.

Si una idea no esta clara, marcar:

```text
Estado: Necesita contexto
```

## UI sugerida

Añadir un boton:

```text
Generar ideas Content Bank
```

Opcional:

- pestaña Content Bank
- vista previa de `esta_semana.md`
- boton para abrir `Salida/ContentBank/`

## Objetivo semanal

El archivo `esta_semana.md` debe recomendar 2 piezas:

- una visual del juego
- una de comunidad, pregunta, rareza, carta, bug gracioso o mini lore sin spoilers

## Validacion

Probar con una nota simple del dia y confirmar que se crean los archivos en `Salida/ContentBank/`.

Ejecutar:

```text
dotnet build -c Release
```

## Entrega

Crear resumen en:

```text
Codex_Review/018_content_bank_app_resumen.md
```
