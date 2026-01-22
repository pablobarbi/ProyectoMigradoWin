# ========= CONFIG =========
$sourcePath = "C:\Desarrollo\ProyectoMigradoWin\Minotti\MinottiApp\Metadata\Generated"
$outputFile = "C:\Desarrollo\metadata_map.txt"

# ========= START =========
$lines = @()

Get-ChildItem -Path $sourcePath -Filter "*.cs" | Sort-Object Name | ForEach-Object {

    $className = [System.IO.Path]::GetFileNameWithoutExtension($_.Name)

    if ([string]::IsNullOrWhiteSpace($className)) {
        return
    }

    $lines += "            [`"$className`"] = new $className(),"
}

# Write output
$lines | Set-Content -Encoding UTF8 $outputFile

Write-Host "Metadata map generado en:"
Write-Host $outputFile
