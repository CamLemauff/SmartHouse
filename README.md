# SmartHouse

Cette application permet d'avoir des températures en temps réel en Celsius à partir de capteurs qui mesure la température dans d'autres unités de températures.

## Organisation de l'application
Les capteurs utilisent l'interface Sensor, les visualisateurs utilisent l'interface Visualizer et on a une classe abstraite permettant la conversion des données.

Pour les capteurs, nous utilisons le patron Factory afin de pouvoir rajouter tous les capteurs que l'on veut au fur et à mesure.

On appelle la fonction qui permet de créer un nouveau capteur dans le main du programme et cela permettra de rajouter un nouveau capteur à l'application sans avoir à l'éteindre.
