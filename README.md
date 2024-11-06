# PathManager


PathManager is a CLI tool for managing Windows "Path" environment variable.


#### USING
### Commands

    Usage:
      PathManager [command] [options]

    Options:
      --version       Show version information
      -?, -h, --help  Show help and usage information

    Commands:
      add     Add path to environment variable.
      remove  Remove path from environment variable.

### Command "add"

    Description:
      Add path to environment variable.

    Usage:
      PathManager add [options]

    Options:
      -d, --directory <path> (REQUIRED)  The directory path that is added to the "Path" environment variable.
      -s, --system                       Select if you want to add/remove the directory path to/from the system instead of
                                         user environment "Path" variable. (Required administrator permissions!) [default:
                                         False]
      -f, --first                        Select if you want to add the directory path to the beginning of the "Path"
                                         environment variable. [default: False]
      -?, -h, --help                     Show help and usage information

### Command "remove"

    Description:
      Remove path from environment variable.

    Usage:
      PathManager remove [options]

    Options:
      -d, --directory <path> (REQUIRED)  The directory path that is added to the "Path" environment variable.
      -s, --system                       Select if you want to add/remove the directory path to/from the system instead of
                                         user environment "Path" variable. (Required administrator permissions!) [default:
                                         False]
      -?, -h, --help                     Show help and usage information


#### EXAMPLES

    PathManager add "C:\Path\To Directory" --system
    PathManager add "C:\Path\To Directory" --system --first
    PathManager add C:\Path\To\Directory
    PathManager add "C:\Path\To Directory" -f
    PathManager add C:\Path\To\Directory --first
    PathManager remove "C:\Path\To Directory" -s
    PathManager remove C:\Path\To\Directory
    PathManager -?
    PathManager -h
    PathManager -help
    PathManager add -h
    PathManager remove --help
