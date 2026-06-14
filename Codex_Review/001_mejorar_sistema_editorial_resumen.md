# 001 - Mejorar sistema editorial

## Tarea realizada

Se implementó la mejora editorial solicitada en la issue #2 y en `Aiko_To_Codex/001_mejorar_sistema_editorial.md`.

## Archivos modificados

- `Form1.cs`
- `README.md`

## Funciones nuevas

- Botón **Analizar material** para generar archivos editoriales sin preparar todo el borrador base.
- Generación de `diagnostico_editorial.md`.
- Generación de `titulos_y_descripciones.md`.
- Generación de `recomendaciones_publicacion.md`.
- Paquete para Aiko ampliado con diagnóstico, títulos, recomendaciones y reglas anti-relleno.

## Cambios principales

- El diagnóstico editorial ahora incluye fecha, número de notas, longitud aproximada, capturas, vídeos, palabras clave, nivel de información, tipo recomendado, motivo, faltantes y contenido publicable.
- La recomendación usa los tipos: devlog completo, mini devlog, solo redes, idea para vídeo, nota interna o no publicar todavía.
- Para notas cortas, WordPress queda marcado como no recomendado todavía salvo que haya material suficiente para devlog completo.
- El paquete para Aiko pide analizar antes de redactar y generar solo el contenido que tenga sentido.

## Pruebas realizadas

- `dotnet build -c Release`
- Prueba automatizada temporal con la nota:

`Dia de las nubes, eventos de cartas y un limon gigante disponible.`

Resultado de la prueba:

`ISSUE_2_EDITORIAL_TEST_OK`

Validó que:

- se genera `diagnostico_editorial.md`
- se genera `titulos_y_descripciones.md`
- se genera `recomendaciones_publicacion.md`
- se genera `paquete_para_aiko.md`
- la nota corta se clasifica como nivel bajo
- recomienda `solo redes` o `mini devlog`
- no fuerza WordPress como formato fuerte
- el paquete incluye reglas anti-relleno y formato flexible

## Problemas encontrados

Durante la primera prueba, `recomendaciones_publicacion.md` todavía permitía WordPress para `mini devlog`. Se ajustó para que solo `devlog completo` recomiende WordPress como publicación fuerte.

## Limitaciones

- El análisis editorial usa reglas locales simples, no IA integrada.
- No separa automáticamente la respuesta de Aiko por secciones finales.
- Las palabras clave detectadas salen de una lista local básica.

## Próximos pasos

- Probar con varios días reales de desarrollo.
- Añadir selector de día para analizar jornadas anteriores.
- Mejorar la detección de palabras clave según ejemplos reales de Caos Entre Reinos: Reborn.
