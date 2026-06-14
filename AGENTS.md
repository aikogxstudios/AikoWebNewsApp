# AGENTS.md - AikoGx Studios

Este repositorio usa un flujo de trabajo **Aiko -> Codex -> Fagner/Fak**.

Aiko organiza las tareas, define el criterio y prepara instrucciones claras. Codex ejecuta cambios técnicos dentro del repositorio. Fagner/Fak revisa, prueba y aprueba.

## Reglas generales para Codex

1. Lee siempre la tarea completa antes de tocar archivos.
2. No rehagas el proyecto desde cero salvo que la tarea lo pida de forma explícita.
3. No toques archivos fuera del alcance indicado.
4. No inventes features que no hayan sido pedidas.
5. Mantén el estilo, estructura y tecnología existente del proyecto.
6. Prioriza cambios pequeños, seguros y fáciles de revisar.
7. Si falta información, deja la tarea como bloqueada y explica qué falta.
8. No integres APIs externas, servicios de pago, publicación automática ni automatizaciones peligrosas sin aprobación explícita.
9. Si modificas código, intenta compilar o indicar cómo probarlo.
10. Al terminar, crea un resumen en `Codex_Review/`.

## Formato del resumen en Codex_Review

Cada tarea terminada debe dejar un archivo Markdown con este formato:

`YYYY-MM-DD_resumen_nombre_tarea.md`

Debe incluir:

- Tarea realizada.
- Archivos modificados.
- Cambios principales.
- Pruebas realizadas.
- Problemas encontrados.
- Pendientes o recomendaciones.

## Carpetas de flujo

- `Aiko_To_Codex/`: tareas preparadas por Aiko.
- `Codex_Review/`: resúmenes generados por Codex tras ejecutar tareas.
- `Codex_Done/`: tareas ya revisadas y aceptadas.

## Frase guía

**Aiko piensa y organiza. Codex ejecuta. Fagner decide y aprueba.**
