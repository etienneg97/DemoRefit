# DemoRefit

## Fonctionnalités principales
- Consommation d’API REST via des interfaces C# annotées avec Refit.
- Injection de services Refit dans les composants Blazor.
- Exemple CRUD sur une ressource Book (livre).
- Récupération de la date serveur via une API dédiée.
- Gestion des paramètres de requête (tri, limite, filtres par identifiants).
- Utilisation d'un handler pour mettre la langue dans les appels API.

## Structure du projet
- Refit/IBookApiService.cs : Interface Refit pour les opérations sur les livres.
- Refit/IDateApiService.cs : Interface Refit pour récupérer la date serveur.
- Refit/RefitBootstrapper.cs : Méthodes d’enregistrement des clients Refit.
- Pages/BookPage.razor & .cs : Exemple d’utilisation des services Refit dans un composant Blazor.
- Parameters/BookParameters.cs : Modèle pour les paramètres de requête.