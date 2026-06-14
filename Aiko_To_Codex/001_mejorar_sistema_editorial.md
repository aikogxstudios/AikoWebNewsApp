# Tarea Aiko para Codex - Mejorar sistema editorial

## Contexto

La app ya organiza notas, capturas, videos y genera archivos Markdown. El problema actual es que el contenido sale generico: una nota pequena puede convertirse en un devlog demasiado largo y repetitivo.

Queremos que Aiko Web News App funcione como asistente editorial, no como generador de relleno.

## Objetivo

Mejorar la app para que analice el material del dia y decida que formato conviene:

- devlog completo
- mini devlog
- solo redes
- idea para video
- nota interna
- no publicar todavia

La app no debe usar APIs externas ni IA real. Solo debe preparar mejores archivos, diagnosticos y paquetes para Aiko/ChatGPT.

## Archivos o zonas que puede tocar

- Form1.cs
- Form1.Designer.cs
- README.md
- Plantillas si existen
- Logica local de generacion Markdown
- Carpetas de salida creadas por la app

## Archivos o zonas protegidas

- No borrar AGENTS.md
- No borrar Aiko_To_Codex
- No borrar Codex_Review
- No borrar Codex_Done
- No eliminar el flujo GitHub ya creado
- No rehacer la app desde cero

## Cambios requeridos

### 1. Diagnostico editorial

Crear al preparar contenido un archivo:

`Dias/YYYY-MM-DD/Salida/diagnostico_editorial.md`

Debe incluir:

- fecha
- numero de notas detectadas
- longitud aproximada de notas
- numero de capturas
- numero de videos
- palabras clave detectadas
- nivel de informacion: bajo, medio o alto
- tipo recomendado: devlog completo, mini devlog, solo redes, idea video, nota interna o no publicar todavia
- motivo de la recomendacion
- que falta para mejorar
- que se puede publicar hoy

### 2. Reglas simples de decision

Nivel bajo:
- nota muy corta
- sin capturas
- sin videos
- poco contexto

Recomendar: solo redes, nota interna o no publicar todavia.

Nivel medio:
- varias notas o una nota clara
- alguna captura o video
- avance entendible

Recomendar: mini devlog, Discord, X o idea video.

Nivel alto:
- notas detalladas
- varios avances claros
- material visual suficiente
- sistema importante

Recomendar: devlog completo.

### 3. Titulos y descripciones

Crear:

`Dias/YYYY-MM-DD/Salida/titulos_y_descripciones.md`

Debe incluir:

- titulos recomendados segun formato
- titulo elegido
- subtitulo si aplica
- descripcion corta
- extracto WordPress si aplica
- meta descripcion si aplica
- motivo del titulo elegido

### 4. Recomendaciones de publicacion

Crear:

`Dias/YYYY-MM-DD/Salida/recomendaciones_publicacion.md`

Debe incluir:

- plataforma recomendada
- orden recomendado de publicacion
- categoria WordPress si aplica
- tags WordPress si aplica
- hashtags si aplica
- imagen o video recomendado
- riesgo de que se sienta pobre: bajo, medio o alto
- que falta antes de publicar

### 5. Mejorar paquete_para_aiko.md

El paquete debe pedir a Aiko que primero analice y luego decida. Debe incluir esta regla:

No generes una entrada larga si el material no lo justifica. Decide el formato correcto y genera solo el contenido que tenga sentido.

Debe incluir:

- notas reales
- capturas detectadas
- videos detectados
- diagnostico editorial local
- reglas contra relleno
- formato flexible de salida

### 6. Evitar relleno

Agregar reglas en el paquete:

- No rellenar por rellenar
- No repetir la misma idea muchas veces
- No inventar mecanicas, lore ni fechas
- No prometer fechas
- No decir terminado si algo esta en prueba
- Si falta informacion, decirlo claramente
- Si el material es corto, generar contenido corto
- Si el material es visual, recomendar video o imagen
- Si el material es tecnico, recomendar devlog
- Si el material es raro o divertido, recomendar redes

### 7. Interfaz

Si es sencillo, agregar:

- boton Analizar material
- boton Ver diagnostico editorial
- etiqueta visible con la recomendacion: Devlog completo, Mini devlog, Solo redes, Nota interna o No publicar todavia

Si complica mucho, priorizar archivos Markdown y estabilidad.

## Resultado esperado

La app debe dejar de forzar devlogs largos.

Debe ayudar a decidir que publicar, donde publicarlo, con que titulo, que tags usar y que falta para que el contenido no se sienta pobre.

## Validacion

Probar con una nota corta como:

`Dia de las nubes, eventos de cartas y un limon gigante disponible.`

Resultado esperado:

- nivel de informacion bajo
- recomendado: solo redes o avance corto
- WordPress no recomendado todavia
- pedir captura del limon gigante y mas contexto

## Al terminar

Crear resumen en:

`Codex_Review/001_mejorar_sistema_editorial_resumen.md`

Incluir:

- archivos modificados
- funciones nuevas
- pruebas realizadas
- limitaciones
- proximos pasos
