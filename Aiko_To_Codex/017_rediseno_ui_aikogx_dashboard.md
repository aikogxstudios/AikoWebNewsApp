# Tarea Aiko para Codex - 017 Rediseño UI AikoGx Dashboard

## Estado

Lista para ejecutar.

La issue #4 / tarea 016 ya fue revisada y cerrada como completada. El resumen `Codex_Review/016_reparar_notas_organizadas_y_branding_resumen.md` confirma que el branding general AikoGx, las notas organizadas y la seguridad WordPress quedaron validados. Esta tarea 017 es la siguiente fase.

## Contexto general

La app ya funciona a nivel tecnico y editorial, pero visualmente todavia se siente como una herramienta tecnica con muchos botones visibles. Fagner/Fak quiere que se sienta como un dashboard interno premium de AikoGx Studios: clara, bonita, ordenada y facil de usar.

Importante: esta app es para todo AikoGx Studios, no solo para Caos Entre Reinos. Caos puede seguir siendo el proyecto activo por defecto, pero la marca visible debe ser AikoGx Studios.

## Contexto de Drive estudiado por Aiko

Aiko reviso documentos de Google Drive del chat anterior antes de preparar esta tarea:

- `Aiko Web News App - Plan editorial y briefing para Codex`
- `Auditoria de perfiles y redes - AikoGx Studios`

Conclusiones importantes de esos documentos:

1. La app no necesita mas texto por rellenar; necesita mejor criterio editorial.
2. No debe convertir una nota pequena en un devlog largo.
3. Debe ayudar a decidir si algo va a web, Discord, X, TikTok/Shorts, nota interna o si no conviene publicar todavia.
4. La identidad de AikoGx debe ser coherente: mismo nombre, tono, pitch, tags y enlaces cuando se usen.
5. El tono debe ser indie, cercano, honesto, claro y con personalidad AikoGx.
6. Caos Entre Reinos debe sonar colorido, caotico, raro, aventurero y vivo, no dark fantasy generico.
7. La app debe ser centro de decision editorial, no solo generador de plantillas.

## Lo que Codex ya hizo antes

No repetir estas tareas salvo que sea necesario para conectar la UI:

### 001 - Sistema editorial

Ya existe:

- boton `Analizar material`
- `diagnostico_editorial.md`
- `titulos_y_descripciones.md`
- `recomendaciones_publicacion.md`
- paquete para Aiko con reglas anti-relleno
- clasificacion por nivel de informacion y tipo recomendado

### 002 - WordPress borradores seguros

Ya existe:

- boton `Crear borrador WordPress`
- boton `Abrir borrador manual`
- estado WordPress forzado siempre a `draft`
- bloqueo si `defaultStatus` no es `draft`
- fallback manual si no hay config o falla la API
- proteccion de `Config/wordpress_config.json`

### 014 - Organizador de notas de desarrollador

Ya existe:

- boton `Organizar notas`
- `notas_organizadas.md`
- separacion de avances reales, material visual, bugs/pruebas, ideas futuras, notas confusas, posibles posts cortos y recomendacion editorial
- inclusion de notas organizadas en el paquete para Aiko

### 016 - Reparar notas organizadas y branding general

Ya existe:

- cabecera general AikoGx Studios
- la app no se presenta solo como Caos Entre Reinos
- `notas_organizadas.md` no repite la nota cruda completa en todas partes
- `ui rara` se trata como problema/contexto pendiente
- `no se si meterlo aun` se trata como duda o idea pendiente
- `limon gigante` se clasifica como material visual o posible post corto
- titulos limpios, no copiados de la nota cruda
- WordPress borradores se mantuvo seguro

Importante: la 016 confirma que NO se hizo rediseño visual grande. Eso es exactamente lo que toca ahora.

## Objetivo de esta tarea

Rediseñar la interfaz de Aiko Web News App como un dashboard interno de AikoGx Studios.

Debe sentirse como:

- panel de mando editorial
- app interna premium
- organizador visual de flujo
- centro para decidir que contenido merece publicarse y donde

No debe sentirse como:

- formulario basico
- lista caotica de botones
- generador automatico de marketing
- app solo de Caos Entre Reinos

## Reglas obligatorias

- Mantener WinForms .NET 8.
- No migrar a WPF, MAUI, web ni Electron.
- No rehacer la app desde cero.
- No romper funciones existentes.
- No eliminar botones/acciones actuales sin dejar alternativa visible.
- No tocar ni debilitar la seguridad de WordPress.
- WordPress debe seguir creando solo borradores `draft`.
- Mantener fallback manual de WordPress.
- No subir credenciales.
- No usar assets externos sin licencia.
- No meter APIs nuevas.
- No crear automatizacion de publicacion.
- No ejecutar tareas futuras completas como branding 005, selector de dia 004 o historial 013 salvo una integracion visual minima si hace falta.

## Alcance tecnico recomendado

Trabajar principalmente en:

- `Form1.cs`
- `BuildUi()`
- helpers visuales existentes como `MakeButton`, `MakePreviewBox`, `MakePreviewPage`
- nuevos helpers visuales simples si ayudan, por ejemplo:
  - `MakeCardPanel`
  - `MakeSectionTitle`
  - `MakeStatusChip`
  - `MakeStepButton`
  - `MakeSmallMetricCard`

Se permite crear controles WinForms personalizados simples solo si no complica demasiado.

## Direccion visual

Estilo: dark dashboard AikoGx.

Paleta sugerida:

- Fondo: `#080B18` o `#0B1020`
- Panel oscuro: `#12182A`
- Panel claro: `#18213A`
- Cian: `#58F3FF`
- Azul: `#3C7BFF`
- Morado: `#8A4DFF`
- Magenta: `#FF4FD8`
- Texto principal: `#F4F7FF`
- Texto secundario: `#AEB8D9`
- Warning: `#FFD166`
- Success: `#62FFB4`

Usar fuentes del sistema si es mas seguro, por ejemplo Segoe UI. Mejorar jerarquia con tamanos, negritas y espaciado.

## Layout objetivo V1

### 1. Header superior

Debe mostrar claramente:

- `Aiko Web News App`
- subtitulo: `Dashboard editorial interno de AikoGx Studios.`
- descripcion corta: `Organiza avances, revisa material y prepara borradores para publicar manualmente.`
- proyecto activo secundario: `Proyecto activo: Caos Entre Reinos: Reborn`

Tambien puede mostrar una etiqueta tipo:

- `Modo seguro: WordPress siempre en borrador`

### 2. Columna izquierda - Captura rapida

Card principal: `Notas del dia`

Debe incluir:

- caja de notas grande
- boton principal `Guardar nota`
- botones secundarios pequenos:
  - `Abrir carpeta del dia`
  - `Abrir salida`

La zona de notas debe sentirse como area de escritura importante, no como caja escondida.

### 3. Parte superior derecha - Estado del dia

Crear cards pequenas de estado:

- Notas
- Capturas
- Videos
- Diagnostico
- Paquete Aiko
- Respuesta Aiko
- WordPress draft

Estados visuales sugeridos:

- Pendiente
- Listo
- Requiere contexto
- Bloqueado

No hace falta crear una logica enorme nueva. Usar señales existentes:

- si hay texto en notas = notas listas
- si hay archivos en Capturas = capturas listas
- si hay archivos en Videos = videos listos
- si existe `diagnostico_editorial.md` = diagnostico listo
- si existe `paquete_para_aiko.md` = paquete listo
- si existe `respuesta_aiko.md` = respuesta lista
- si existe borrador manual o indicio de WordPress draft = WordPress preparado

### 4. Centro derecha - Flujo principal por pasos

Mostrar un flujo numerado y claro, no una sopa de botones:

1. Crear/Cargar dia
2. Importar material
3. Organizar notas
4. Analizar material
5. Generar paquete para Aiko
6. Guardar respuesta de Aiko
7. Preparar borrador WordPress

Cada paso puede ser una card, fila o boton grande con descripcion corta.

Botones actuales deben seguir existiendo, pero agrupados de forma mas clara.

### 5. Estado de publicacion

Crear una seccion visible llamada:

`Estado de publicacion`

Debe usar el diagnostico existente cuando sea posible.

Estados posibles:

- Sin material
- Necesita contexto
- Listo para redes
- Listo para mini update
- Listo para devblog web
- Listo para borrador WordPress
- Borrador WordPress creado

Regla UX:

- Si el diagnostico no recomienda WordPress, el boton WordPress no debe ser la accion principal visual.
- Si hay poca informacion, destacar redes o nota interna.
- Si hay informacion alta, destacar web / borrador WordPress.
- Si falta contexto, mostrarlo como aviso, no como error tecnico.

### 6. Zona inferior derecha - Vista previa

Tabs limpias sugeridas:

- Diagnostico
- Notas organizadas
- Aiko
- Web
- Redes
- WordPress

Si no es practico cambiar todas las tabs en esta primera fase, como minimo mejorar la visual y dejar el codigo preparado para añadir tabs despues.

## Integracion ligera con tareas futuras

Estas tareas existen pero NO se deben ejecutar completas ahora:

- `003_mejorar_keywords_caos.md`
- `004_selector_dia_anterior.md`
- `005_perfiles_y_branding_app.md`
- `006_exportar_paquete_zip.md`
- `007_checklist_prepublicacion.md`
- `008_modo_luna_nails.md`
- `009_publicador_manual_discord_x.md`
- `010_modo_revision_aiko.md`
- `011_panel_estado_proyecto.md`
- `012_export_wordpress_html_limpio.md`
- `013_guardar_historial_publicaciones.md`
- `015_plantillas_por_tipo_contenido.md`

Pero la 017 puede inspirarse especialmente en `011_panel_estado_proyecto.md`, porque encaja con el dashboard. Hacer solo una version visual basica de estado del dia si ayuda, sin convertirlo en un sistema grande.

## Assets

Opcional:

Crear carpeta:

`Assets/AikoGxUI/`

Se pueden crear SVG simples propios si ayuda:

- `aiko_orb.svg`
- `icon_notes.svg`
- `icon_media.svg`
- `icon_aiko.svg`
- `icon_wordpress.svg`
- `icon_check.svg`
- `icon_warning.svg`

Si complica la carga de assets en WinForms, mejor dibujar con colores, labels, paneles y botones. No usar imagenes externas.

## Animaciones y feedback

Permitido solo si es simple y seguro:

- hover en botones cambiando color/borde
- glow sutil en boton principal
- chips de estado con color
- mensajes de estado mas claros

No hacer animaciones complejas con Timer si puede romper estabilidad.

## Validacion obligatoria

Probar flujo minimo:

1. Abrir app.
2. Crear dia actual.
3. Guardar nota.
4. Importar o detectar material si existe.
5. Organizar notas.
6. Analizar material.
7. Generar paquete para Aiko.
8. Guardar respuesta de Aiko.
9. Crear borrador manual/WordPress.

Comprobar:

- No desaparece funcionalidad existente.
- No se rompen botones actuales.
- WordPress sigue forzado a `draft`.
- Fallback manual sigue funcionando.
- No se suben credenciales.
- La app compila.

Comandos:

```powershell
dotnet build -c Release
dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64
```

## Resultado esperado

La app debe sentirse mas parecida a un dashboard interno de AikoGx:

- ordenada
- visualmente atractiva
- menos ruido
- flujo guiado
- acciones claras
- estado visible
- preparada para trabajar con varios proyectos de AikoGx en el futuro
- sin perder la seguridad editorial ya implementada

## Al terminar

Crear resumen en:

`Codex_Review/017_rediseno_ui_aikogx_dashboard_resumen.md`

El resumen debe incluir:

- tarea realizada
- archivos modificados
- cambios visuales principales
- funciones existentes preservadas
- si se tocaron o no reglas WordPress
- pruebas realizadas
- resultado de build
- resultado de publish
- problemas encontrados
- pendientes o mejoras futuras

## Nota final para Codex

Esta tarea es principalmente de UI/UX y organizacion visual. No intentes resolver todo el backlog. El objetivo es que Fagner/Fak abra la app y entienda rapidamente:

1. que material tiene hoy,
2. que falta,
3. que recomienda la app,
4. cual es el siguiente paso,
5. y que nada se publica automaticamente.
