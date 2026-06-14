# Aiko Web News App

Aplicación local de escritorio para Windows creada con **C# .NET 8** y **WinForms**.

Sirve para organizar contenido diario de desarrollo de **AikoGx Studios** y preparar material para revisar y publicar manualmente en WordPress, Discord, X, TikTok y YouTube Shorts. El proyecto por defecto puede ser **Caos Entre Reinos: Reborn**, pero la herramienta no está limitada a un solo juego.

La app no publica nada automáticamente, no integra APIs externas y no usa IA dentro de la aplicación. El nuevo **Modo Aiko** genera un paquete/prompt local para copiarlo en ChatGPT/Aiko y guardar después la respuesta final.

## Ejecutar la app

Abre directamente:

`publish\win-x64\AikoWebNewsApp.exe`

La publicación actual es **self-contained win-x64**, así que está pensada para abrirse sin instalar .NET Runtime aparte.

## Flujo recomendado

1. Pulsa **Crear día actual**.
2. Importa capturas y vídeos.
3. Escribe notas reales del día.
4. Pulsa **Organizar notas** si tus notas están caóticas.
5. Pulsa **Analizar material** o **Preparar contenido** para generar el diagnóstico editorial.
6. Pulsa **Generar paquete para Aiko**.
7. Revisa la etiqueta de recomendación o abre **Ver diagnóstico editorial**.
8. Pega el paquete en ChatGPT/Aiko.
9. Copia la respuesta de Aiko.
10. Pégala en la pestaña **Respuesta de Aiko**.
11. Pulsa **Guardar respuesta de Aiko**.
12. Revisa los `.md` finales en `Salida` y `Borradores`.

## Dashboard editorial

La pantalla principal funciona como un centro de mando interno de AikoGx Studios:

- notas del dia como materia prima
- cards de estado para notas, capturas, videos, diagnostico, paquete Aiko, respuesta y WordPress
- flujo principal por pasos
- estado de publicacion visible
- vistas previas para diagnostico, notas organizadas, Aiko, web, redes, WordPress y material

El boton **Preparar contenido base** queda como herramienta secundaria. El flujo principal recomendado es organizar notas, analizar material y generar el paquete para Aiko antes de preparar borradores finales.

## Crear un día

La app crea o verifica:

`Dias\YYYY-MM-DD`

Cada día contiene:

- `Capturas`
- `Videos`
- `Notas`
- `Seleccionado`
- `Salida`

## Guardar notas

Escribe la nota del día en el panel izquierdo y pulsa **Guardar nota rápida**.

La nota se guarda en:

`Dias\YYYY-MM-DD\Notas\nota_rapida.md`

## Importar capturas y vídeos

Las capturas se copian en:

`Dias\YYYY-MM-DD\Capturas`

Los vídeos se copian en:

`Dias\YYYY-MM-DD\Videos`

Si ya existe un archivo con el mismo nombre, se renombra como `captura_1.png`, `captura_2.png`, `video_1.mp4`, etc.

## Preparar contenido

El botón **Preparar contenido** genera un **borrador base** con plantillas locales y crea un diagnóstico editorial.

Archivos generados en `Dias\YYYY-MM-DD\Salida`:

- `entrada_web.md`
- `post_discord.md`
- `post_x.md`
- `ideas_tiktok.md`
- `ideas_youtube_shorts.md`
- `resumen_del_dia.md`
- `imagenes_recomendadas.md`
- `notas_organizadas.md`
- `diagnostico_editorial.md`
- `titulos_y_descripciones.md`
- `recomendaciones_publicacion.md`

## Organizador de notas

El botón **Organizar notas** lee las notas del día y genera:

`Dias\YYYY-MM-DD\Salida\notas_organizadas.md`

Este archivo separa la materia prima del desarrollador en:

- resumen limpio del día
- avances reales detectados
- material visual o destacable
- bugs, pruebas o problemas
- ideas futuras o pendientes
- notas confusas o con poco contexto
- posibles posts cortos
- recomendación editorial

El paquete para Aiko incluye estas notas organizadas y avisa de que no debe convertir notas confusas en afirmaciones públicas.

También copia esos borradores a:

`Borradores\YYYY-MM-DD`

## Content Bank

Pulsa **Generar ideas Content Bank** para crear ideas locales destinadas al repo `AikoGx-ContentBank`.

La app genera:

`Dias\YYYY-MM-DD\Salida\ContentBank\`

Con estos archivos:

- `paquete_para_contentbank.md`
- `ideas_tiktok_shorts.md`
- `esta_semana.md`
- `necesitan_clip.md`
- `necesitan_captura.md`
- `reciclables.md`
- `publicaciones_realizadas_template.md`

Este flujo no publica nada, no conecta con GitHub y no toca WordPress. Las ideas son material para revisar y copiar manualmente. Si una idea no está clara, queda marcada como `Estado: Necesita contexto`.

## Modo Aiko

Pulsa **Generar paquete para Aiko**.

La app lee:

- notas guardadas en `Notas`
- nombres de capturas en `Capturas`
- nombres de vídeos en `Videos`
- archivos `.md` ya generados en `Salida`

Y genera:

`Dias\YYYY-MM-DD\Salida\paquete_para_aiko.md`

También intenta copiar el paquete al portapapeles.

Este paquete está pensado para pegarlo en ChatGPT/Aiko y pedir una versión mejor redactada, usando solo el material real del día.

Antes de pedir contenido largo, el paquete incluye una fase editorial para que Aiko decida si conviene preparar:

- devlog completo
- mini devlog
- solo redes
- idea para vídeo
- nota interna
- no publicar todavía

La app no fuerza una entrada web larga cuando hay poca información. Si el material del día es pequeño, el paquete pide a Aiko que prepare solo lo que tenga sentido.

## Diagnóstico editorial

La app genera:

`Dias\YYYY-MM-DD\Salida\diagnostico_editorial.md`

Este archivo incluye:

- cantidad de notas detectadas
- cantidad de capturas detectadas
- cantidad de vídeos detectados
- resumen real del material del día
- nivel de información: bajo, medio o alto
- tipo de contenido recomendado
- motivo de la recomendación
- qué falta para una entrada web fuerte
- qué contenido sí se puede preparar hoy
- títulos recomendados y descripción corta
- recomendación de plataformas, tags, hashtags y riesgo de publicación pobre

Puedes abrirlo con **Ver diagnóstico editorial**.

## Respuesta de Aiko

En la pestaña **Respuesta de Aiko** puedes:

- pegar la respuesta devuelta por ChatGPT/Aiko
- pulsar **Guardar respuesta de Aiko**
- copiar el paquete con **Copiar paquete para Aiko**
- abrir el archivo con **Abrir paquete para Aiko**

La respuesta se guarda en:

`Dias\YYYY-MM-DD\Salida\respuesta_aiko.md`

Y también se copia a:

`Borradores\YYYY-MM-DD\respuesta_aiko.md`

## Vista previa y copiar

La app muestra vista previa de:

- entrada web
- post Discord
- post X
- respuesta de Aiko

También puedes copiar al portapapeles:

- entrada web
- Discord
- X
- paquete para Aiko

## Marcar como publicado

Cuando ya hayas publicado manualmente, pulsa **Marcar como publicado**.

La app copia los `.md` generados a:

`Publicados\YYYY-MM-DD`

Y crea un archivo `publicado.txt` con la fecha y hora.

## WordPress borradores

La app puede preparar una entrada en WordPress, pero siempre en estado **draft**. Nunca usa `publish`, no programa publicaciones y no publica automáticamente.

Botones disponibles:

- **Crear borrador WordPress**: intenta crear un borrador vía WordPress REST API.
- **Abrir borrador manual**: abre el archivo HTML local preparado para copiar y pegar.

Contenido usado por prioridad:

1. `Dias\YYYY-MM-DD\Salida\respuesta_aiko.md`
2. `Dias\YYYY-MM-DD\Salida\entrada_web.md`

La app intenta leer título, extracto, categoría y tags desde:

- `titulos_y_descripciones.md`
- `recomendaciones_publicacion.md`

### Configuración local

Copia:

`Config\wordpress_config.example.json`

Como:

`Config\wordpress_config.json`

Y rellena tus datos localmente:

```json
{
  "siteUrl": "https://aikogx.es",
  "username": "",
  "applicationPassword": "",
  "defaultCategoryId": null,
  "defaultStatus": "draft"
}
```

`Config\wordpress_config.json` está ignorado por Git y no debe subirse al repositorio.

### Application Password

En WordPress:

1. Entra en tu usuario.
2. Abre Perfil.
3. Busca **Application Passwords**.
4. Crea una nueva contraseña para Aiko Web News App.
5. Copia esa contraseña en `applicationPassword`.

### Modo manual

Si falta configuración, está incompleta o WordPress devuelve un error, la app no pierde contenido y crea:

- `wordpress_borrador_manual.md`
- `wordpress_borrador_manual.html`

Estos archivos contienen título, extracto, categoría sugerida, tags y contenido para copiar manualmente en WordPress.

## Carpetas raíz

La app crea estas carpetas junto al `.exe`:

- `Inbox`
- `Dias`
- `Borradores`
- `Publicados`
- `Plantillas`
- `Exportados`
- `Config`
- `Logs`

## Limitaciones de esta versión

- No publica automáticamente.
- No publica automáticamente en WordPress, Discord, X, TikTok ni YouTube.
- No usa OpenAI API.
- No integra Ollama.
- No edita imágenes.
- No edita vídeos.
- No separa todavía automáticamente la respuesta de Aiko por secciones.
- La IA se usa manualmente copiando y pegando el paquete en ChatGPT/Aiko.
- El diagnóstico editorial usa reglas locales simples, no IA integrada.

## Mejoras futuras posibles

- Separar automáticamente `respuesta_aiko.md` en archivos finales por plataforma.
- Selector de días anteriores.
- Editor de plantillas desde la app.
- Previsualización de imágenes.
- Historial de publicaciones.
- Integraciones opcionales, siempre con confirmación manual.
