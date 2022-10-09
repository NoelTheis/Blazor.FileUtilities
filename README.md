# Blazor.FileUtilities
 Provides easy methods for downloading or opening files in a Blazor application.

 This is just a small wrapper around a bit of javascript that can turn a stream
 into a blob and either open it in a new window or trigger a download.

 Uploading was not part of the goal as the existing [Solution](https://learn.microsoft.com/en-us/aspnet/core/blazor/file-uploads?view=aspnetcore-6.0&pivots=webassembly) does not really need much simplification.

 The project relies on [MimeTypesMap](https://github.com/hey-red/MimeTypesMap) to figure out the correct mime type for opening files.

## Targets
    .Net 6
## Usage

Add services.
```csharp
Services.AddBlazorFileUtilities();
```

Inject the service into any component.
```csharp
@using Blazor.FileUtilities

@inject FileService FileService
```

Open file from stream. The file name (with extension) is required to figure out the correct mime type.
```csharp
await FileService.Open(stream, FileName);
```
Alternatively the mime type can be supplied directly.
```csharp
await FileService.Open(stream, FileName, useMimeType: true);
```
Download file from stream.
```csharp
await FileService.Download(stream, FileName);
```

## License
[MIT](LICENSE)