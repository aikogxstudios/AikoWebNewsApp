# 014 - Organizador de notas de desarrollador

## Tarea realizada

Se añadió un organizador local de notas para separar materia prima caótica antes de generar contenido público o paquete para Aiko.

## Archivos modificados

- `Form1.cs`
- `README.md`
- `Codex_Review/014_organizador_notas_desarrollador_resumen.md`

## Cómo se organiza la nota

La app lee las notas del día y genera:

`Dias/YYYY-MM-DD/Salida/notas_organizadas.md`

El archivo separa:

- resumen limpio del día
- avances reales detectados
- material visual o destacable
- bugs, pruebas o problemas
- ideas futuras o pendientes
- notas confusas o con poco contexto
- posibles posts cortos
- recomendación editorial

También se añadió el botón **Organizar notas** y la generación automática dentro de:

- Analizar material
- Preparar contenido
- Generar paquete para Aiko

El paquete para Aiko incluye `notas_organizadas.md` y avisa de que no debe convertir notas confusas en afirmaciones públicas.

## Pruebas realizadas

- `dotnet build -c Release`
- Prueba temporal automatizada con la nota:

`dia nubes evento cartas limon gigante disponible ui rara no se si meterlo aun video pendiente`

Resultado:

`DEVELOPER_NOTES_ORGANIZER_TEST_OK`

Validó que:

- se genera `notas_organizadas.md`
- existen secciones de avances, visual, confusas y posts cortos
- se conserva el elemento llamativo `limon gigante`
- se marca o separa contenido con poco contexto
- `paquete_para_aiko.md` incluye las notas organizadas y la instrucción de uso seguro

## Limitaciones

- La clasificación usa reglas locales simples por palabras clave.
- No usa IA integrada.
- Frases muy compactas pueden clasificarse de forma conservadora como material visual, redes o contexto pendiente.

## Próximos pasos

- Ajustar palabras clave con ejemplos reales de notas de Fak.
- Añadir vista previa de `notas_organizadas.md` si se vuelve necesario.
- Usar este archivo como base para futuras plantillas por tipo de contenido.
