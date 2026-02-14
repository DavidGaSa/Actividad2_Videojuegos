### SCRIPT MOVING PLATFORM

En este script nos encargamos de que las plataformas se muevan en direcciones. Para ello usamos como referencia 1 cubo que se encarga de señalizar las coordenadas para volver a la posición inicial y que desaparece al comenzar el juego (por estética).

### SCRIPT PLAYER CONTROLLER

Es la lógica principal del jugador: movimientos, seguimiento de la camara, mirar hacia donde me voy a mover, el salto, la velocidad que lleva, etc. En este script quiero destacar la creacion de una variable que se llama aireRozamiento, cuyo objetivo es que al saltar el jugador no se acelere en el aire como si no hubiera fuerzas contrarias al salto.
Otro aspecto a destacar el modelo visual (hacia donde mira el jugador) por medio de quaterniones para que parezca que el usuario se mueve más acorda al input que le dan las teclas.

### SCRIPT FALLING PLATFORMS

Indicamos que al detectar que el jugador ha tocado la plataforma (OnCollisionEnter), esta se destruye pasado un tiempo de 0.3s (ajustables por el usuario).

### SCRIPT REAPARECER

En este script le indicamos al jugador que reaparezca en el lugar de origen del juego. Esto lo logramos poniendo un espacio vacío entre 2 planos (uno es el propio suelo u otro un suelo falso). Al traspasar el falso suelo el jugador reaparece en la casilla de salida. Se complementa con el script de PlayerController en la parte final donde está la función Reaparecer.
