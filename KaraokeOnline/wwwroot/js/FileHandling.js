window.CreateUrlFromFile = (inputElem) => {
    // Todo: make this work with the new proper way with audiocontext and stuff.
    if ("srcObject" in Audio) {
        const audioCtx = new AudioContext();
        return source = audioCtx.createMediaElementSource(myAudio);        
    }
    else {
        return URL.createObjectURL(inputElem.element.files[0]);
    }
    
};