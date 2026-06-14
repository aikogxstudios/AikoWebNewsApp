# Tarea Aiko para Codex - Rediseño UI AikoGx Dashboard

## Estado

Tarea futura/proxima fase. No ejecutar hasta terminar la issue #4.

## Contexto

La app funciona, pero visualmente sigue pareciendo una herramienta tecnica llena de botones. Fagner/Fak quiere una app bonita, intuitiva y organizada, inspirada en dashboards oscuros/neon como la referencia enviada.

La app debe sentirse como herramienta interna de AikoGx Studios, no como formulario basico.

## Objetivo

Rediseñar la interfaz de Aiko Web News App con estilo premium dark dashboard:

- menos botones visibles
- flujo claro por pasos
- paneles/cards organizados
- acentos cian, azul, morado y magenta
- estilo AikoGx Studios
- visual limpio, no caotico
- pequenas animaciones/hover si WinForms lo permite sin complicar

Mantener WinForms .NET 8. No migrar a WPF, MAUI, web ni Electron.

## Cambio de marca visible

La app no debe presentarse solo como Caos Entre Reinos.

Texto sugerido:

`Organiza avances de AikoGx Studios y prepara borradores locales para revisar y publicar manualmente.`

Puede mantener `Proyecto activo: Caos Entre Reinos: Reborn` como dato seleccionable o texto secundario.

## Layout recomendado

### Columna izquierda - Captura rapida

Card: `Notas del dia`

- caja de notas grande
- boton principal: Guardar nota
- botones secundarios pequeños: Abrir carpeta, Abrir salida

### Parte superior derecha - Estado del dia

Cards pequeñas:

- Notas
- Capturas
- Videos
- Diagnostico
- Paquete Aiko
- WordPress draft

Cada card con estado visual:

- pendiente
- listo
- requiere contexto
- bloqueado

### Centro derecha - Flujo principal

Un flujo de pasos numerados:

1. Crear/Cargar dia
2. Importar material
3. Organizar notas
4. Analizar material
5. Generar paquete para Aiko
6. Guardar respuesta de Aiko
7. Preparar borrador WordPress

Mostrar pocos botones principales, no todos a la vez. Agrupar por fase.

### Abajo derecha - Vista previa

Tabs limpias:

- Diagnostico
- Notas organizadas
- Aiko
- Web
- Redes
- WordPress

## Animaciones y feedback

WinForms permite algo simple:

- hover en botones cambiando color/borde
- transicion suave opcional usando Timer
- etiqueta de estado con pequeno pulso si esta pendiente
- glow sutil en boton de accion principal

No meter animaciones complejas si ponen en riesgo estabilidad.

## Assets

Crear carpeta:

`Assets/AikoGxUI/`

Se pueden crear assets simples generados por Codex en formato SVG o PNG si es sencillo:

- aiko_orb.svg
- card_glow.svg
- icon_notes.svg
- icon_media.svg
- icon_aiko.svg
- icon_wordpress.svg
- icon_check.svg
- icon_warning.svg

No usar imagenes de Google ni assets sin licencia.

Si no se puede generar PNG facil, usar SVG o dibujar formas con WinForms.

## Paleta sugerida

- Fondo: #080B18 o #0B1020
- Panel: #12182A
- Panel claro: #18213A
- Cian: #58F3FF
- Azul: #3C7BFF
- Morado: #8A4DFF
- Magenta: #FF4FD8
- Texto principal: #F4F7FF
- Texto secundario: #AEB8D9
- Warning: #FFD166
- Success: #62FFB4

## Tipografia

Mantener fuentes del sistema si es mas seguro. Usar tamaños y pesos para jerarquia:

- titulo grande
- subtitulo pequeño
- secciones claras
- botones de accion destacables

## Readiness editorial

Añadir una seccion visible tipo:

`Estado de publicacion`

Estados posibles:

- Sin material
- Necesita contexto
- Listo para redes
- Listo para mini update
- Listo para devblog web
- Listo para borrador WordPress
- Borrador WordPress creado

La app debe mostrar esto usando el diagnostico existente.

Regla:

- Si el diagnostico recomienda WordPress no recomendado, no destacar boton WordPress como accion principal.
- Si el diagnostico ve informacion baja, destacar redes o nota interna.
- Si informacion alta, destacar preparar web y borrador WordPress.

## WordPress

Mantener seguridad existente:

- nunca publicar automaticamente
- solo estado draft
- fallback manual
- no subir credenciales

## Resultado esperado

La app debe sentirse mas parecida a un dashboard interno de AikoGx:

- ordenada
- visualmente atractiva
- menos ruido
- flujo guiado
- acciones claras
- estado visible

## Validacion

Probar:

- abrir app
- crear dia
- guardar nota
- analizar material
- generar paquete
- guardar respuesta
- crear borrador manual/WordPress

Comprobar:

- no desaparece funcionalidad existente
- no se rompen botones actuales
- compila con `dotnet build -c Release`
- publicar exe actualizado con `dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64`

## Al terminar

Crear resumen en:

`Codex_Review/017_rediseno_ui_aikogx_dashboard_resumen.md`
