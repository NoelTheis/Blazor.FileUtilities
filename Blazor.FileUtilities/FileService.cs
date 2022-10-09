using HeyRed.Mime;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;

namespace Blazor.FileUtilities;

public class FileService : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public event Func<InputFileChangeEventArgs, Task>? FileSelectRequested;

    public FileService(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blazor.FileUtilities/blazor.fileUtilities.js").AsTask());
    }

    public async ValueTask Open(
        Stream stream, 
        string extensionOrMimeType, 
        bool useMimeType = false)
    {
        var mimeType = useMimeType ? extensionOrMimeType : MimeTypesMap.GetMimeType(extensionOrMimeType);
        using var streamRef = new DotNetStreamReference(stream);

        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("openFile", streamRef, mimeType);
    }

    public async ValueTask Download(
        Stream stream,
        string fileName)
    {
        using var streamRef = new DotNetStreamReference(stream);

        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("downloadFile", streamRef, fileName);
    }

    public async ValueTask TriggerUpload(string inputId)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("triggerUpload", inputId);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}