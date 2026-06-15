# 024 - Reemplazar flujo diario por siguiente paso claro

Estado: lista para Codex
Fecha: 2026-06-15

## Contexto

Fak reviso la seccion `Flujo de trabajo diario` del dashboard.

Actualmente se ve como una fila de cajas:

1. Capturar Notas/material
2. Organizar Contexto
3. Recomendar Formato
4. Crear Borrador
5. Revisar Manual seguro

El problema es que parece una fila de botones o pasos clicables, pero no queda claro si son navegacion, estado real o decoracion. Ocupa espacio y no ayuda bastante a entender que hacer ahora.

## Objetivo

Reemplazar esa seccion por una tarjeta mas util: `Siguiente paso recomendado`.

La app debe decir claramente:

- que fase esta completada;
- cual es el paso actual;
- que debe hacer Fak ahora;
- cual es el boton principal para continuar.

## Cambio solicitado

Quitar o reducir mucho la fila actual de 5 cajas.

Sustituirla por una card visible en Inicio:

```text
Siguiente paso recomendado

Estado de hoy:
Notas guardadas: Si/No
Material visual: Si/No
Analisis: Si/No
Resultado Aiko: Si/No
WordPress: Draft seguro

Ahora toca:
[texto claro segun estado]

[Boton principal]
```

## Logica recomendada

Si no hay notas:

```text
Ahora toca: escribe o pega una nota del dia.
Boton: Ir a Notas del Dia
```

Si hay notas pero no analisis:

```text
Ahora toca: analizar las notas con Aiko.
Boton: Analizar con Aiko
```

Si hay analisis pero no respuesta de Aiko:

```text
Ahora toca: revisar la recomendacion y generar paquete para Aiko.
Boton: Generar paquete para Aiko
```

Si hay respuesta de Aiko pero no Content Bank:

```text
Ahora toca: guardar ideas utiles en Content Bank o preparar borrador.
Boton: Generar Content Bank
```

Si hay WordPress draft:

```text
Ahora toca: revisar manualmente antes de publicar fuera de la app.
Boton: Abrir borrador manual / carpeta salida
```

## Detalles visuales

La card debe ser mas clara que decorativa:

- titulo grande: `Siguiente paso recomendado`;
- color de acento morado/magenta para el paso actual;
- chips pequeños para estados: Notas, Material, Analisis, Resultado, Draft;
- un unico boton principal destacado;
- texto corto, no parrafos largos.

## Reglas

- No tocar la logica de WordPress draft.
- No publicar automaticamente.
- No conectar GitHub.
- Mantener WinForms .NET 8.
- Usar solo Fak como nombre visible.
- No rehacer toda la UI.
- Esta tarea solo afecta la seccion de flujo/siguiente paso.

## Validacion

Probar estos estados:

1. Sin notas.
2. Con nota guardada.
3. Tras analizar con Aiko.
4. Tras generar paquete Aiko.
5. Tras generar Content Bank o borrador WordPress.

Comprobar que la card cambia texto y boton principal segun el estado.

Ejecutar:

```text
dotnet build -c Release
```

Publicar:

```text
dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64
```

## Entrega

Crear resumen en:

```text
Codex_Review/024_reemplazar_flujo_diario_por_siguiente_paso_resumen.md
```
