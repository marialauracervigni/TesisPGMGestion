var areYouReallySure = false;
function areYouSure() {
	if (allowPrompt) {
		if (!areYouReallySure && true) {
			areYouReallySure = true;
			var confMessage = "";
			return confMessage;
		}
	} else {
		allowPrompt = true;
	}
}

var allowPrompt = true;
window.onbeforeunload = areYouSure;