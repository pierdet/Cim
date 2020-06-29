# CIM - Connection Inventory Manager 
## Building / Running
```bash
git clone https://github.com/pierdet/Cim.git
cd Cim/Cim.Con/
dotnet run
```
## Installing
1. Download the latest [release](https://github.com/pierdet/cim/releases/latest) for your OS platform
2. Extract the contents and copy it somewhere to your PATH
3. Invoke the application by typing "cim" in the command line, this will also create the database so the first run is a bit slow.
#### Input
```bash
user@localhost> cim
```
#### Output:
```bash
cim 1.0.0
Copyright (C) 2020 cim

ERROR(S):
  No verb selected.

  add        Add hosts to an inventory

  create     Create a new inventory

  delete     Delete an inventory

  list       List inventories

  remove     Remove hosts from an inventory

  test       Test network connection to hosts in inventories

  help       Display more information on a specific command.

  version    Display version information.
```
## Usage
The `--help` command can be invoked both directly after `cim` or after specifying a verb
#### Example 1 - Initial help
```bash
cim --help
```
```bash
cim 1.0.0
Copyright (C) 2020 cim

  add        Add hosts to an inventory

  create     Create a new inventory

  delete     Delete an inventory

  list       List inventories

  remove     Remove hosts from an inventory

  test       Test network connection to hosts in inventories

  help       Display more information on a specific command.

  version    Display version information.
```
#### Example 2 - Verb help
```bash
cim create --help
```
```bash
cim 1.0.0
Copyright (C) 2020 cim

  -i, --inventory-name    Required. Specify the name of the inventory to create

  --help                  Display this help screen.

  --version               Display version information.
```
#### Example 3 - Creating an inventory, adding hosts and testing them
### Creating the inventory
#### Input:
```bash
cim create -i webservers
```
#### Output:
```bash
Created inventory webservers
```
### Adding hosts to the inventory
#### Input:
```bash
cim add -i webservers -h google.com facebook.com github.com
```
### Testing the inventory
#### Input:
```bash
cim test -i webservers
```
#### Output:
```bash
Testing connection to hosts in webservers:
google.com is reachable
facebook.com is reachable
github.com is reachable
```
