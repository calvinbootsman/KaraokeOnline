export function PlayAudio(ElementId) {
    var x = document.getElementById(ElementId);
    x.volume = 0.2;
    x.play();
}
export function PauseAudio(ElementId) {
    var x = document.getElementById(ElementId);
    x.pause();
}

export function StopAudio(ElementId) {
    var x = document.getElementById(ElementId);
    x.pause();
    x.currentTime = 0;
}

export function SeekAudio(ElementId, time) {
    var x = document.getElementById(ElementId);
    var currentTime = x.currentTime;
    x.currentTime += time;
}

export function GetCurrentTime(ElementId) {
    var x = document.getElementById(ElementId);
    if (x === null) return 0.0;
    if (x.currentTime === null) return 0.0;
    return x.currentTime;
}

export function SubscribeToTimeUpdates(audioElementId, textElementId) {
    var audioElement = document.getElementById(audioElementId);
    var textElement = document.getElementById(textElementId);

    if (audioElement === null) {
        console.log("audioElement is null")
        return;
    }
    if (textElement === null) {
        console.log("textElementId is null")
        return;
    }

    audioElement.ontimeupdate = function () {
        textElement.innerText = SecondsToTimeStamp(audioElement.currentTime);
    };
}

export function SetPlaybackSpeed(audioElementId, speed) {
    var audioElement = document.getElementById(audioElementId);
    if (audioElement === null) {
        console.log("audioElement is null")
        return;
    }

    audioElement.playbackRate = speed;
}
function SecondsToTimeStamp(time) {
    var date = new Date(time * 1000);
    var mm = date.getUTCMinutes();
    var ss = date.getSeconds();
    var ms = date.getMilliseconds();

    if (ms < 10) { ms = "0" + ms; }
    if (mm < 10) { mm = "0" + mm; }
    if (ss < 10) { ss = "0" + ss; }
    // This formats your string to mm:ss:ms
    var t = mm + ":" + ss + ":" + ms;
    return t;
}