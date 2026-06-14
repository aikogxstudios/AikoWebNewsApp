# Tarea Aiko para Codex - Organizador de notas de desarrollador

## Contexto

Fak escribe notas dentro de la app de forma rapida, mezclada y caotica. Esas notas no son texto final. Son materia prima de desarrollo.

La app ya genera diagnostico editorial y borradores, pero falta una capa importante: organizar esas notas como lo haria un desarrollador antes de convertirlas en contenido publico.

## Objetivo

Agregar un organizador de notas que lea las notas del dia y genere una version limpia, separada y util para Aiko.

La app debe ayudar a distinguir entre:

- avances reales
- bugs
- pruebas
- ideas futuras
- decisiones de diseno
- cosas visuales
- bromas o notas raras
- texto sin contexto suficiente
- material que no debe publicarse todavia

## Resultado principal

Crear al analizar material o preparar contenido:

`Dias/YYYY-MM-DD/Salida/notas_organizadas.md`

Ese archivo debe ordenar la informacion antes de generar el paquete para Aiko.

## Reglas editoriales

1. No todo lo que aparece en notas debe usarse en contenido publico.
2. Si una frase no tiene contexto, marcarla como "requiere contexto".
3. Si algo parece una broma interna, marcarlo como "posible contenido para redes".
4. Si algo parece bug o problema tecnico, separarlo como "bug/prueba".
5. Si algo parece avance real, separarlo como "avance publicable".
6. Si algo parece idea futura, no presentarlo como hecho.
7. Si el material es pobre, recomendar contenido corto.
8. Si hay material suficiente, permitir devlog largo.

## Secciones del archivo notas_organizadas.md

Debe incluir:

### Resumen limpio del dia
Una version corta y ordenada de lo que realmente paso.

### Avances reales detectados
Lista de cosas que parecen avances hechos o probados.

### Material visual o destacable
Cosas que dependen de capturas o videos.

### Bugs, pruebas o problemas
Cosas que no deberian venderse como avance final.

### Ideas futuras o pendientes
Cosas que pueden salir en roadmap, pero no como promesa.

### Notas confusas o con poco contexto
Frases que Aiko no deberia usar sin preguntar.

### Posibles posts cortos
Ideas que sirven para Discord, X o una frase breve.

### Recomendacion editorial
Decidir si el dia va mejor como devlog, mini devlog, redes, video, nota interna o no publicar.

## Integracion con paquete_para_aiko.md

El paquete para Aiko debe incluir `notas_organizadas.md` si existe.

El paquete debe decir claramente:

"Estas notas ya han sido organizadas. Usa solo los avances reales y el material con contexto. No conviertas notas confusas en afirmaciones publicas."

## Interfaz

Si es sencillo, agregar boton:

- Organizar notas

Si complica mucho, integrar la funcion dentro de:

- Analizar material
- Preparar contenido
- Generar paquete para Aiko

Prioridad: estabilidad antes que botones nuevos.

## Ejemplo de comportamiento

Nota original:

`dia nubes evento cartas limon gigante disponible ui rara no se si meterlo aun video pendiente`

Salida esperada:

Avances reales:
- Se trabajo en un evento relacionado con cartas.
- Hay un elemento destacable: limon gigante disponible.

Material visual:
- El limon gigante podria funcionar mejor con captura o video.

Notas confusas:
- "ui rara" necesita mas contexto.
- "no se si meterlo aun" indica que no debe presentarse como confirmado.

Recomendacion:
- Post corto para Discord/X o nota interna.
- No hacer devlog web largo todavia.

## Validacion

Probar con notas caoticas y comprobar que:

- genera `notas_organizadas.md`
- no mete frases sin sentido en avances reales
- separa dudas y cosas incompletas
- recomienda formato corto si toca
- mejora el paquete para Aiko

## Al terminar

Crear resumen en:

`Codex_Review/014_organizador_notas_desarrollador_resumen.md`

Incluir:

- archivos modificados
- como se organiza la nota
- pruebas realizadas
- limitaciones
- proximos pasos
