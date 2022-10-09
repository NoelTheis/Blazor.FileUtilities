export async function downloadFile(contentStreamReference, fileName) {
    try {
        let arrayBuffer = await contentStreamReference.arrayBuffer();
        let blob = new Blob([arrayBuffer]);
        let url = URL.createObjectURL(blob);
        let link = document.createElement('a');
        link.href = url;
        link.download = fileName;
        link.click();
        link.remove();
        URL.revokeObjectURL(url);
    }
    catch (error) {
        console.error(error);
    }
}

export async function openFile(contentStreamReference, mimeType) {
    try {
        let arrayBuffer = await contentStreamReference.arrayBuffer();
        let blob = new Blob([arrayBuffer], { type: mimeType });
        let url = window.URL.createObjectURL(blob);
        let link = document.createElement('a');
        link.href = url
        link.target = '_blank';
        link.click();
        link.remove
        URL.revokeObjectURL(url);
    }
    catch (error) {
        console.error(error);
    }
}

export async function triggerUpload(inputId) {
    let input = document.getElementById(inputId);
    if (input === null)
        return;
    input.click();
}