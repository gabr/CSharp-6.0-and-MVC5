$iis = "C:\Program Files (x86)\IIS Express\iisexpress.exe"
$config_path = ".vs/config/applicationhost.config"
$site_name = "ANOUC"

start chrome "http:\\localhost:64835"

& $iis /config:$config_path /site:$site_name #/trace:error

