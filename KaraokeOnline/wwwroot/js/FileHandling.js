window.CreateUrlFromFile = (inputElem) => {
    return URL.createObjectURL(inputElem.element.files[0]);
};