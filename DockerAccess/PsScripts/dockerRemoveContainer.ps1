#Script to remove a container forcefully
param(
   [Parameter(Position=0)]
   $container
)
docker rm -f $container