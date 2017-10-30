ilspy
start-sleep 5

# get all dlls
$grouped_dlls = dir -recurse -file -filter *.dll |
  # group by file names
  group Name

"$($grouped_dlls.Count) dlls to load"

  # load only last one from each group
$grouped_dlls | foreach {
    $dll_path = $_.Group[-1].FullName
    $dll_path #print out
    ilspy $dll_path
  }

