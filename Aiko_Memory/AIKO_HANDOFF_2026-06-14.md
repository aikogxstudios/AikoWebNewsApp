# Aiko handoff - 2026-06-14

Este archivo resume lo importante de la conversacion larga para continuar en otro chat sin perder contexto.

## Identidad de Aiko

- Aiko es el asistente principal de Fagner/Fak y AikoGx Studios.
- Aiko actua como organizador, editor, apoyo creativo, gestor de tareas y puente con Codex.
- Tono: español casual, cercano, claro, directo y honesto.
- Aiko no debe limitarse a decir si algo se puede o no; debe buscar caminos practicos.
- Regla guia: Aiko piensa y organiza. Codex ejecuta. Fagner decide y aprueba.
- Aiko debe proteger el foco del usuario y evitar meter sistemas grandes sin necesidad.

## Estado emocional importante

- Fagner/Fak esta pasando un duelo por el fallecimiento de su abuela.
- Su abuela lo crio, educo y fue una figura central para el.
- Tratar este tema con cuidado, calma y humanidad.
- No presionar con productividad cuando este emocionalmente mal.

## Proyecto principal

- Proyecto principal: AikoGx Studios.
- Juego principal: Caos Entre Reinos: Reborn / Chaos Among Realms: Reborn.
- La app de noticias NO debe ser solo para Caos Entre Reinos; debe servir para todo AikoGx Studios.
- Caos Entre Reinos puede ser proyecto activo, pero la herramienta debe estar pensada para cualquier proyecto de AikoGx.

## App actual

Repositorio:
https://github.com/aikogxstudios/AikoWebNewsApp

App:
Aiko Web News App, WinForms C# .NET 8.

Ruta del ejecutable publicado:
H:\AppAikoGxNews\publish\win-x64\AikoWebNewsApp.exe

Objetivo de la app:
- organizar notas, capturas y videos diarios
- analizar si el contenido sirve para web, redes, video, nota interna o si no conviene publicar
- generar paquete para Aiko/ChatGPT
- guardar respuesta de Aiko
- preparar borradores locales y borradores de WordPress
- nunca publicar automaticamente

## Flujo actual de la app

1. Crear dia actual.
2. Guardar notas rapidas.
3. Importar capturas y videos.
4. Organizar notas / Analizar material.
5. Generar paquete para Aiko.
6. Pegar paquete en ChatGPT/Aiko.
7. Guardar respuesta de Aiko en la app.
8. Crear borrador WordPress o borrador manual.
9. Fagner revisa y publica manualmente.

## Funciones ya implementadas por Codex

### Tarea 001 - Sistema editorial

Implementado:
- boton Analizar material
- diagnostico_editorial.md
- titulos_y_descripciones.md
- recomendaciones_publicacion.md
- paquete_para_aiko.md con reglas anti-relleno
- evita devlogs largos cuando la nota es pobre

Validado con la nota:
`Dia de las nubes, eventos de cartas y un limon gigante disponible.`

### Tarea 002 - WordPress borradores seguros

Implementado:
- boton Crear borrador WordPress
- boton Abrir borrador manual
- estado WordPress forzado siempre a draft
- fallback manual si no hay config o falla la API
- Config/wordpress_config.json protegido por gitignore
- Config/wordpress_config.example.json creado

Regla clave:
La app nunca debe publicar automaticamente.

### Tarea 003/014 - Organizador de notas de desarrollador

Objetivo:
Fagner escribe notas caoticas. La app debe tratarlas como materia prima, no como texto final.

Debe separar:
- avances reales
- material visual
- bugs/pruebas
- ideas futuras
- notas confusas
- posibles posts cortos
- recomendacion editorial

### Tarea 016 - Reparar notas organizadas y branding general AikoGx

Codex ya completo la reparacion:
- cabecera general AikoGx Studios
- no solo Caos Entre Reinos
- notas_organizadas.md no debe repetir la nota cruda en todas partes
- ui rara se marca como problema/contexto pendiente
- no se si meterlo aun se marca como duda o idea pendiente
- limon gigante se clasifica como material visual o posible post corto
- titulos limpios, no copiados de la nota cruda
- WordPress borradores sigue seguro

## Tarea siguiente preparada

Archivo:
Aiko_To_Codex/017_rediseno_ui_aikogx_dashboard.md

Objetivo:
Rediseñar la app como dashboard interno premium de AikoGx Studios.

Direccion visual:
- dark dashboard
- azul profundo / casi negro
- acentos cian, morado y magenta
- menos botones visibles
- cards claras
- flujo por pasos
- estados visuales del contenido
- intuitiva y organizada
- no caotica visualmente
- mantener WinForms .NET 8

No migrar a WPF, MAUI, web ni Electron.

Inspiracion visual enviada:
- interfaz dark/neon tipo dashboard futurista
- cards limpias
- energia cian/morada
- estructura de app moderna

## Backlog de tareas Aiko_To_Codex

Tareas existentes o futuras:
- 003_mejorar_keywords_caos.md
- 004_selector_dia_anterior.md
- 005_perfiles_y_branding_app.md
- 006_exportar_paquete_zip.md
- 007_checklist_prepublicacion.md
- 008_modo_luna_nails.md
- 009_publicador_manual_discord_x.md
- 010_modo_revision_aiko.md
- 011_panel_estado_proyecto.md
- 012_export_wordpress_html_limpio.md
- 013_guardar_historial_publicaciones.md
- 014_organizador_notas_desarrollador.md
- 015_plantillas_por_tipo_contenido.md
- 016_reparar_notas_organizadas_y_branding.md
- 017_rediseno_ui_aikogx_dashboard.md

## Reglas de contenido

- No rellenar por rellenar.
- No convertir una frase corta en un devlog largo.
- No inventar sistemas, mecanicas, lore ni fechas.
- No decir que algo esta terminado si esta en prueba.
- Si falta contexto, decirlo.
- Si la nota es rara/divertida, puede servir para redes.
- Si hay sistema explicado, puede servir para devlog.
- Si hay material visual, puede servir para video o imagen.
- Si hay duda o idea futura, no presentarla como hecho.

## WordPress

Objetivo final:
La app debe preparar borradores en WordPress, no publicar.

Flujo deseado:
- Aiko organiza y redacta
- app prepara entrada
- boton Crear borrador WordPress
- WordPress queda en Draft/Borrador
- Fagner revisa manualmente y publica si quiere

Si API falla:
- crear wordpress_borrador_manual.md
- crear wordpress_borrador_manual.html

## Como continuar en un chat nuevo

Mensaje recomendado para nuevo chat:

"Aiko, continuamos desde el archivo Aiko_Memory/AIKO_HANDOFF_2026-06-14.md del repo aikogxstudios/AikoWebNewsApp. Mantén tu rol como Aiko de AikoGx Studios y seguimos con la app Aiko Web News App. La siguiente fase es revisar o ejecutar el rediseño UI AikoGx Dashboard."
