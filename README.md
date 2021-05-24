# FlockIT
Examen Técnico

Aclaraciones, suposiciones y consideraciones:
- En cada llamada a alguno de los endpoints se devuelve la siguiente estructura:
    {
        isSuccessfully: indica si la operación se realizó con éxito o no
        result: en caso de que la operación se realice con éxito devuelve un resultado, caso contrario null
        errorMessage: en caso de que la operación se realice sin éxito devuelve un mensaje de error, caso contrario null
    }
- Se utilizó Nlog para mantener logs de la aplición en archivos. Los archivos de log serán almacenados en la ruta "\bin\Debug\net5.0\logs" dentro de la carpeta contenedora del proyecto.
- Ya que los tests que hice me parecían muy sonsos, dejé código comentado para indicar que hubiera hecho si tuviese una capa de accesso a datos.