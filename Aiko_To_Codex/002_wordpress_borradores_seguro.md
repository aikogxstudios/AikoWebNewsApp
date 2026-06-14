# Tarea Aiko para Codex - WordPress borradores seguros

## Contexto

La tarea editorial #1 ya mejoro el criterio de la app: ahora genera diagnostico editorial, titulos, recomendaciones y paquete para Aiko sin forzar devlogs largos.

El siguiente objetivo de empresa es preparar el puente hacia la web de AikoGx Studios sin publicar automaticamente.

La app NO debe publicar entradas directamente. Debe poder crear una entrada en WordPress en estado borrador para que Fak revise y publique manualmente desde WordPress.

## Objetivo

Agregar un sistema seguro para crear borradores de WordPress desde la app.

Resultado deseado:

- Boton: Crear borrador WordPress
- La app crea una entrada en WordPress con estado `draft`
- Nunca usa estado `publish`
- Nunca publica automaticamente
- Si no hay configuracion WordPress, genera un archivo listo para copiar manualmente
- Si WordPress falla, no se pierde nada y queda log claro

## Prioridad

Implementar primero una version simple, segura y local.

No hace falta que sea perfecta. Debe ser estable, facil de entender y sin riesgo de publicar por accidente.

## Archivos o zonas que puede tocar

- Form1.cs
- Form1.Designer.cs
- README.md
- Configuracion local de la app
- Generacion de archivos Markdown/HTML
- .gitignore si hace falta proteger secretos

## Archivos o zonas protegidas

- No borrar AGENTS.md
- No borrar Aiko_To_Codex
- No borrar Codex_Review
- No borrar Codex_Done
- No romper el flujo editorial ya creado
- No publicar automaticamente
- No subir contrasenas, tokens ni credenciales al repo

## Reglas de seguridad obligatorias

1. El estado de WordPress debe ser siempre `draft`.
2. No usar `publish`, `future` ni estados automaticos.
3. No guardar credenciales reales en GitHub.
4. Las credenciales deben ir en archivo local ignorado por git.
5. Si falta configuracion, la app debe mostrar mensaje claro y crear archivo local listo para copiar.
6. Si ocurre error HTTP, guardar log local y no marcar como subido.
7. No borrar borradores locales despues de enviar a WordPress.
8. No subir imagenes automaticamente en esta primera version salvo que sea estrictamente sencillo y seguro. Si complica, dejarlo para tarea futura.

## Configuracion propuesta

Crear o usar archivo local:

`Config/wordpress_config.json`

Debe estar ignorado por git.

Campos propuestos:

```json
{
  "siteUrl": "https://aikogx.es",
  "username": "",
  "applicationPassword": "",
  "defaultCategoryId": null,
  "defaultStatus": "draft"
}
```

Tambien crear un ejemplo seguro para subir al repo:

`Config/wordpress_config.example.json`

Sin credenciales reales.

## Funcionamiento recomendado

Al pulsar Crear borrador WordPress:

1. Leer el contenido final recomendado.
2. Prioridad de contenido:
   - `Dias/YYYY-MM-DD/Salida/respuesta_aiko.md` si existe
   - si no existe, `entrada_web.md`
   - si no hay contenido suficiente, cancelar y avisar
3. Leer titulo desde `titulos_y_descripciones.md` si existe.
4. Leer recomendaciones/tags desde `recomendaciones_publicacion.md` si existe.
5. Crear payload para WordPress REST API:

```json
{
  "title": "titulo",
  "content": "contenido",
  "status": "draft",
  "excerpt": "extracto si existe"
}
```

6. Enviar a:

`/wp-json/wp/v2/posts`

7. Usar Basic Auth con usuario + application password.
8. Si funciona, guardar:

`Dias/YYYY-MM-DD/Salida/wordpress_borrador_resultado.md`

con:

- fecha
- titulo enviado
- estado usado
- id del borrador si WordPress lo devuelve
- enlace de edicion si se puede obtener
- enlace de vista previa si se puede obtener
- aviso: revisar manualmente antes de publicar

## Fallback obligatorio sin API

Si no hay config o falla la API, crear:

`Dias/YYYY-MM-DD/Salida/wordpress_borrador_manual.html`

y/o

`Dias/YYYY-MM-DD/Salida/wordpress_borrador_manual.md`

Con:

- titulo
- contenido
- extracto
- categorias sugeridas
- tags sugeridos
- instrucciones para copiar a WordPress manualmente

## Interfaz

Agregar si es sencillo:

- Boton: Crear borrador WordPress
- Boton: Abrir borrador manual
- Etiqueta de estado: Borrador creado / falta configuracion / error

Si complica demasiado, priorizar la funcion y los archivos generados.

## README

Actualizar README con una seccion:

`WordPress borradores`

Debe explicar:

- la app nunca publica directamente
- solo crea borradores
- como crear application password en WordPress
- donde poner config local
- que el archivo real de config no se sube a GitHub
- como usar modo manual si no hay API

## Validacion

Probar minimo:

1. Sin `Config/wordpress_config.json`:
   - no debe fallar
   - debe crear borrador manual
   - debe avisar que falta configuracion

2. Con config incompleta:
   - no debe publicar
   - debe mostrar error claro

3. Revisar que ningun codigo use `status = publish`.

4. Ejecutar:

`dotnet build -c Release`

## Al terminar

Crear resumen en:

`Codex_Review/002_wordpress_borradores_seguro_resumen.md`

Incluir:

- archivos modificados
- como se usa
- que pasa si no hay config
- pruebas realizadas
- limitaciones
- proximos pasos
