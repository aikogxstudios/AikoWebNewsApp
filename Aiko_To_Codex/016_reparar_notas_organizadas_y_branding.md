# Tarea Aiko para Codex - Reparar notas organizadas y branding general AikoGx

## Contexto

Se probo el paquete para Aiko con una nota caotica:

`dia nubes evento cartas limon gigante disponible ui rara no se si meterlo aun video pendiente`

El resultado mejoro la organizacion general, pero todavia falla en puntos importantes:

- La app sigue presentandose como si fuera solo para Caos Entre Reinos.
- Debe servir para todo AikoGx Studios.
- `notas_organizadas.md` repite la misma nota cruda en varias secciones.
- Marca la nota completa como material visual, bug y idea futura a la vez.
- Dice que no hay notas confusas, aunque claramente hay frases sin contexto como `ui rara` y `no se si meterlo aun`.
- Los titulos generados son feos porque copian la nota cruda completa.
- El paquete para Aiko todavia arrastra ruido en vez de ofrecer una version limpia.

## Objetivo

Reparar el organizador de notas para que actue como filtro editorial real antes de generar contenido.

Tambien cambiar el texto principal de la app para que no diga que es solo de Caos Entre Reinos. Debe ser una app de AikoGx Studios para organizar contenido de cualquier proyecto.

## Cambios requeridos

### 1. Cambiar texto de cabecera

Cambiar cualquier texto tipo:

`Organiza avances de Caos Entre Reinos: Reborn y prepara borradores locales para publicar manualmente.`

por una frase mas general:

`Organiza avances de AikoGx Studios y prepara borradores locales para revisar y publicar manualmente.`

O una variante similar.

La app puede seguir teniendo campo/proyecto por defecto `Caos Entre Reinos: Reborn`, pero el producto no debe parecer exclusivo de ese juego.

### 2. Mejorar notas_organizadas.md

No repetir la nota cruda completa en todas las secciones.

La app debe dividir la nota en fragmentos o interpretar palabras clave simples.

Para la nota de prueba:

`dia nubes evento cartas limon gigante disponible ui rara no se si meterlo aun video pendiente`

Salida esperada aproximada:

Resumen limpio:
- Hay una nota rapida sobre un posible evento de cartas, un elemento visual de limon gigante, un posible ajuste raro de UI y un video pendiente.

Avances reales:
- Posible evento relacionado con cartas.
- Elemento destacable: limon gigante disponible.

Material visual:
- Limon gigante.
- Video pendiente.
- Nubes si existe captura o contexto visual.

Bugs/pruebas/problemas:
- UI rara. Requiere mas contexto antes de publicarlo.

Ideas futuras o pendientes:
- No se si meterlo aun. No presentarlo como confirmado.
- Video pendiente.

Notas confusas:
- `dia nubes` necesita mas contexto.
- `ui rara` necesita explicar que pasa.
- `no se si meterlo aun` indica duda de diseno.

Posibles posts cortos:
- Mostrar el limon gigante como curiosidad visual si hay captura.
- Comentar que se estan probando ideas para eventos de cartas.

Recomendacion editorial:
- Solo redes o mini update corto.
- No devlog largo.
- No WordPress fuerte sin captura y contexto.

### 3. Mejorar criterio de tipo recomendado

Si nivel de informacion es bajo y no hay capturas ni videos:

- recomendado principal: `solo redes` o `nota interna`
- no `mini devlog` como primera opcion salvo que haya algo explicable

Si hay una rareza visual pero sin captura:

- recomendar pedir captura
- no generar web todavia

### 4. Mejorar titulos_y_descripciones.md

No usar la nota cruda como titulo.

Con la nota de prueba, titulos aceptables:

- `Pruebas internas con cartas y un limon gigante`
- `Un pequeno experimento visual para AikoGx Studios`
- `Notas rapidas: cartas, nubes y una idea pendiente`

Titulos NO aceptables:

- `Mini devlog: dia nubes evento cartas limon gigante disponible ui rara n...`

### 5. Mejorar paquete_para_aiko.md

El paquete debe incluir una seccion clara:

`Notas limpias para usar`

Y otra:

`Notas que NO deben convertirse en afirmaciones publicas`

El paquete debe decir:

- Usa solo las notas limpias.
- Las notas confusas sirven para pedir contexto, no para publicar.
- Si no hay avances claros, genera solo contenido corto o nota interna.

### 6. No romper WordPress borradores

Mantener funcionando:

- Crear borrador WordPress
- Abrir borrador manual
- estado siempre draft
- fallback manual

## Archivos que puede tocar

- Form1.cs
- Form1.Designer.cs si hace falta cambiar textos visibles
- README.md
- generacion de diagnostico, titulos, recomendaciones y paquete para Aiko

## Archivos protegidos

- AGENTS.md
- carpetas Aiko_To_Codex, Codex_Review, Codex_Done
- configuracion de seguridad de WordPress

## Validacion obligatoria

Probar con:

`dia nubes evento cartas limon gigante disponible ui rara no se si meterlo aun video pendiente`

Debe comprobar:

- `notas_organizadas.md` no repite la nota completa en todas las secciones
- `ui rara` aparece como confusa/problema o requiere contexto
- `no se si meterlo aun` aparece como idea pendiente/no confirmado
- el limon gigante aparece como material visual o posible post corto
- el titulo elegido no copia la nota cruda
- la recomendacion no fuerza devlog web
- la cabecera ya no dice que la app es solo para Caos Entre Reinos

Ejecutar:

`dotnet build -c Release`

## Al terminar

Crear resumen en:

`Codex_Review/016_reparar_notas_organizadas_y_branding_resumen.md`
