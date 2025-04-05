import CryptoJS from 'https://cdn.skypack.dev/crypto-js';


document.querySelector("form").onsubmit = async function (e) {
    e.preventDefault();  // Empêcher l'envoi du formulaire

    let form = this;
    let username = document.getElementById("Username").value;
    let password = document.getElementById("Password").value;

    // Hacher le mot de passe avec SHA-256
    let hashedPassword = CryptoJS.SHA256(password).toString(CryptoJS.enc.Base64);

    // Ajouter le mot de passe haché dans un champ caché
    let hiddenPasswordField = document.createElement("input");
    hiddenPasswordField.type = "hidden";
    hiddenPasswordField.name = "PasswordHash";
    hiddenPasswordField.value = hashedPassword;
    form.appendChild(hiddenPasswordField);

    // Nettoyer le champ original (optionnel)
    document.getElementById("Password").value = "";

    // Soumettre le formulaire
    form.submit();
};



