
# jeuleap
Application **JeuLeap** pour voter avec une main

# description
L'application **JeuLeap** permet d’interagir avec l'API **middleoffice**. Elle permet d'afficher la liste des demandes, puis de voter pour chacune d'entre elles. Il suffit de passer la main droite pour voter oui et la main gauche pour non.

# fonctionnement
- La méthode **GetRequests()** permet de récupérer toutes les demandes, elle effectue une requête de type GET vers /api/Requests.
La méthode retourne une chaîne de caractère contenant la liste des demandes au format JSON.
- La méthode **Vote()** permet de voter pour une requête. Elle reçoit en paramètre l'id de la requête ainsi que le codeAnswer (qui correspond à 1 pour oui et 0 pour non). La méthode effectue une requête POST vers /api/Requests/{id}/Vote en transmettant comme paramètre l'objet answer.
- Les deux méthodes utilisent le header Authorization qui est ajouté à la requête, il permet de s'authentifier avec une identifiant et un mot de passe encodé en base 64.
- La méthode **DisplayRequest()** permet d'afficher une requête par son indice, elle prend en paramètre l'objet requests et l'indice de la requête à afficher.
La méthode retourne l'id de la requête affichée.
# configuration
Variable à configurer :
- urlService : URL de l'API middleoffice
- username : identifiant du Basic Authentication
- password : mot de passe du Basic Authentication

# prérequis

## matériel
- Leap Motion

## softs
- Microsoft Studio 2017
- Leap Motion SDK v2.3.1