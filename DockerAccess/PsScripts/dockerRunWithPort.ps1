#run a container from an image with port mapping
param(
   [Parameter(Position=0)]
   $image
   [Parameter(Position=1)]
   $hostPort
   [Parameter(Position=2)]
   $containerPort
)
docker run -d -p $hostPort:$containerPort $image --daemon