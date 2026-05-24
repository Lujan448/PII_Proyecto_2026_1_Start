# README - Reflexiones del proyecto

## Los desafíos:

Uno de los mayores desafíos fue lograr que la clase Recommendation y la fachada compartieran el mismo objeto History e InteractionManager. 
Al principio cada clase creaba su propio objeto internamente, lo que causaba que los cambios en uno no se reflejaran en el otro.

Sinceramente, la parte más difícil de nuestro programa, sin duda fue la clase Recommendations, primero porque fue difícil decidir cómo estructurar los diferentes tipos de recomendaciones (por preferencias, historial, popularidad, usuarios similares) sin violar SRP. Lo segundo más difícil sin dudas fue implementar algunas de las recomendaciones, ya que había muchas cosas que no conocíamos como se escribian bien en c#, como por ejemplo los diccionarios, y tuvimos que utilizar de los primeros documentos que vimos en clase, el cual fue la "Ayuda de C# para programadores Python".

## Cosas aprendidas fuera de la currícula:

Para resolver el problema de los objetos compartidos decidimos pasar History e InteractionManager por constructor en lugar de crearlos internamente. Si bien este concepto se conoce como inyección de dependencias y no fue visto en clase, nos pareció la solución más correcta para evitar tener dos historiales desconectados. La persona que conoció etse concepto y decidió agregarlo fue Luján Uhalde, la cual conoció esta guía guando estaba estudiando el principio DIP.

## Recursos utilizantes

- Utilizamos todas las lecturas que vimos en el curso y estan disponibles en Webasignatura.
- Además utilizamos los videos del canal de YouTube makigas(https://www.youtube.com/@makigas), en especial el video sobre DIP: https://www.youtube.com/watch?v=OqxpDAjBr8o

Adejuntamos el link del trello:
https://trello.com/invite/b/6a0262bda9c31a4b075d70f2/ATTId96e9ae2f49b4d93269151e3259ebcc1F5264D70/proyecto-p2




