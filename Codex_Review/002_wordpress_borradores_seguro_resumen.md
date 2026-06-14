# 002 - WordPress borradores seguros

## Tarea realizada

Se implementó un flujo seguro para preparar o crear borradores de WordPress desde Aiko Web News App, manteniendo la regla principal: la app nunca publica automáticamente.

## Archivos modificados

- `Form1.cs`
- `README.md`
- `.gitignore`
- `Codex_Review/002_wordpress_borradores_seguro_resumen.md`

## Cómo se usa

1. Preparar contenido del día o guardar `respuesta_aiko.md`.
2. Opcionalmente crear `Config/wordpress_config.json` a partir de `Config/wordpress_config.example.json`.
3. Pulsar **Crear borrador WordPress**.
4. Si la configuración es válida, la app envía una entrada a WordPress con estado `draft`.
5. Si falta configuración o hay error, la app crea un borrador manual local.

También se añadió **Abrir borrador manual** para abrir `wordpress_borrador_manual.html`.

## Seguridad aplicada

- El estado enviado a WordPress se fuerza siempre a `draft`.
- Si `defaultStatus` existe y no es `draft`, no se llama a la API y se crea borrador manual.
- No se usa `publish`, `future` ni estados automáticos.
- No se suben credenciales reales.
- `.gitignore` protege `Config/wordpress_config.json`.
- Si WordPress falla, se registra en `Logs/app.log` y se crea fallback manual.
- No se borran borradores locales después de intentar enviar a WordPress.

## Qué pasa si no hay config

Si falta `Config/wordpress_config.json`, la app no falla. Crea:

- `Dias/YYYY-MM-DD/Salida/wordpress_borrador_manual.md`
- `Dias/YYYY-MM-DD/Salida/wordpress_borrador_manual.html`

El archivo manual incluye título, extracto, categoría sugerida, tags, contenido e instrucciones para copiar en WordPress dejando la entrada como borrador.

## Pruebas realizadas

- `dotnet build -c Release`
- Prueba temporal automatizada:

`WORDPRESS_DRAFT_SAFETY_TEST_OK`

Validó:

- sin `Config/wordpress_config.json`, se crea borrador manual
- con configuración incompleta, se crea borrador manual
- con `defaultStatus = publish`, se bloquea la API y se crea borrador manual
- no se usa `publish` como estado WordPress en `Form1.cs`

## Limitaciones

- No sube imágenes automáticamente.
- No crea categorías o tags en WordPress; solo manda el contenido y opcionalmente `defaultCategoryId`.
- La conversión Markdown a HTML es básica.
- La API requiere usuario y application password configurados manualmente.

## Próximos pasos

- Probar con una instalación real de WordPress usando una application password.
- Añadir selector de categoría/tag si hace falta.
- Mejorar conversión HTML limpia en la tarea de exportación WordPress futura.
