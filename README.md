
# CodeMasterQuiz

C'est un quiz à choix (4 choix) en App Console C#

## Lancement du projet

Pour lancer le projet il suffit de récuperer l'archive du projet de le unzip d'aller dans le dossier CodeMasterQuiz et éffectuer les commandes suivantes

```bash
dotnet build
```
Cela va génére un executable dans le dossier
    
    bin\Debug\net6.0

Il suffit de lancer le .exe et c'est parti ! 

WARNING ne pas lancer le projet avec la commande

```bash
dotnet run
```

Car la features permettant de retrouver les fichiers JSON dans le répertoires n'a pas encore été implémentée 

## Roadmap

- Interface intuitive: Des menus textuels faciles à lire, avec des options numérotées ou marquées clairement pour chaque action (par exemple, "1. Démarrer un Quiz au hasard", "2. Choisir une Catégorie", "3. Quitter").

- Instructions Directes: Fournir des instructions courtes et directes à l'utilisateur sur ce qu'il doit faire ensuite, comme "Veuillez entrer le numéro de votre réponse" ou "Sélectionnez une catégorie en entrant son numéro".

- Gestion Basique des Erreurs : Assurer que l'application gère correctement les entrées utilisateur incorrectes ou inattendues pour éviter tout plantage.

- Questions à Choix Multiples : Chaque question proposera plusieurs réponses (par exemple, quatre choix), parmi lesquelles une seule est correcte. L'utilisateur sélectionne sa réponse, et le système valide immédiatement sa justesse.

- Catégories Variées de Questions : Offrir différentes catégories thématiques telles que C#, Bases de données, Algorithmes, IDE, Frameworks, etc... Les utilisateurs peuvent choisir leur catégorie de prédilection avant de débuter le quiz.

- Système de Questions-Réponses Dynamique : Les utilisateurs répondent aux questions et reçoivent un feedback immédiat après chaque réponse, indiquant si leur choix est correct ou non.

- Compteur de Score : Le score de l'utilisateur est calculé et affiché en fonction du temps et de la difficulté

- Chargement des Questions à partir d'une Source Externe : Possibilité de charger les questions depuis un fichier externe au format texte, CSV ou JSON, facilitant la gestion et la mise à jour du contenu du quiz.



## Features

### Recupération depuis un fichier JSON
Utilisation de la méthode **RecupJsonQuestion()** pour récuperer les données dans le fichier JSON question.json.
#### Structure du fichier JSON
    ```json
    "Quizz": [
        {
            "Category": "",
            "Questions": [
                {
                    "IntituleQuestion": "",
                    "Reponses": [
                        { "Index":1,"InitituleReponse": "" },
                        { "Index":2,"InitituleReponse": "" },
                        { "Index":3,"InitituleReponse": "" },
                        { "Index":4,"InitituleReponse": "" }
                    ],
                    "Resultat":[
                        {"Reponse" : 0,"Descriptif": "","Difficulte":0}
                    ]
                }
            ]
        }
    ]
    ```

Celle-ci est vouée à changer car elle apporte un problème lors de l'ajout d'une catégorie ou d'une question .
### Affichage du ménu principale

Après avoir entrée son nom l'écran du menu de demarrage est affiché avec la méthode **Demarrage()**.

### Affichage du menu de lancement de Quizz

Après avoir démarrer le jeu la méthode **MenuPrincipal()** nous propose un quiz aléatoire ou alors avec un choix de catégorie après le choix la méthode **DebutQuizz()**
ou un booléan est passé en paramètres pour définir si l'utilisateur à choix catégorie précise ou aléatoire.

### Debut du quiz 


#### Choix de la catégorie

Si l'utilisateur à choisir un quiz avec catégorie cela lance la méthode **AfficherQuestionSiCategorie()** qui affiche toutes les catégories du fichier JSON l'utilisateur choisi la catégorie en tapant le chiffre correspondant. Après selection de la catégorie la méthode **AfficherQuestion()** avec des paramètres de catégorie fixe 
les questions elle reste aléatoire.
#### Questions aléatoire

Si les questions aléatoires ont été selectionés la méthode **AfficherQuestion()** avec des paramètres de catégories et de questions choisis aléatoirement.

    int numquiz = rand.Next(source.Count);
    int numquestion = rand.Next(source[numquiz].Quizz[0].Questions.Count);

### Affichage des questions

Les questions sont affichés avec la méthode **AffichageQuesttion()** le patterne est affiché de cette façon

- Numéro de question
- La difficulté de la question
- Les points actuels du joueur 
- L'intitulé de la question 
- les 4 réponses possibles

### Calcul des points 

Après que l'utilisateur est répondu à sa question il obitendra sois un écran de mauvaise réponse donc il obtiendra 0 point, si il répond juste un écran de de bonne réponse sera affiché avec son temps de réponse et les points gagnés. Les points sont calculés de la façon suivantes

    (1-(temps de réponse / temps affecté à la question)/2)*(diffculté de la réponse * 100)

Le temps affecté à la question est par défaut 30 secondes.