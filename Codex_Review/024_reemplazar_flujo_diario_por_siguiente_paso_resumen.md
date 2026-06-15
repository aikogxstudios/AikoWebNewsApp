# 024 - Reemplazar flujo diario por siguiente paso claro

Fecha: 2026-06-15

## Tarea realizada

Se ejecuto `Aiko_To_Codex/024_reemplazar_flujo_diario_por_siguiente_paso.md`.

## Archivos modificados

- `Form1.cs`
- `Codex_Review/024_reemplazar_flujo_diario_por_siguiente_paso_resumen.md`

## Cambios principales

- Se reemplazo la fila `Flujo de trabajo diario` de 5 cajas por la card `Siguiente paso recomendado`.
- La nueva card muestra estados reales con chips:
  - `Notas`
  - `Material`
  - `Analisis`
  - `Resultado`
  - `Draft`
- La card muestra:
  - fase completada;
  - texto corto de `Ahora toca`;
  - un unico boton principal destacado.
- El boton principal cambia segun el estado del dia:
  - sin notas: `Ir a Notas del Dia`;
  - con notas sin analisis: `Analizar con Aiko`;
  - con analisis sin paquete: `Generar paquete para Aiko`;
  - con paquete sin respuesta: `Copiar paquete para Aiko`;
  - con respuesta sin Content Bank: `Generar Content Bank`;
  - con Content Bank sin draft: `Crear borrador draft`;
  - con draft WordPress: `Abrir carpeta Salida`.
- No se modifico la seguridad de WordPress: sigue siendo `draft`.
- No se agrego publicacion automatica ni conexion con GitHub.

## Pruebas realizadas

- `dotnet build -c Release`
- Prueba temporal WinForms de estados:
  - sin notas;
  - con nota guardada;
  - tras `Analizar con Aiko`;
  - tras `Generar paquete para Aiko`;
  - tras guardar respuesta de Aiko;
  - tras generar Content Bank;
  - tras crear borrador WordPress en draft sin mostrar dialogos.
- Resultado de prueba temporal: `NEXT_STEP_CARD_TEST_OK`
- `dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64`

## Resultado de publish

- Ejecutable actualizado:
  - `publish\win-x64\AikoWebNewsApp.exe`

## Problemas encontrados

- No hubo conflictos ni errores de compilacion.

## Pendientes o recomendaciones

- Si mas adelante se crea historial real de publicaciones, el chip `Draft` podria diferenciar entre borrador manual y borrador enviado a WordPress.
