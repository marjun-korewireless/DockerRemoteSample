#start a stopped container
param(
   [Parameter(Position=0)]
   $container
)
docker start $container