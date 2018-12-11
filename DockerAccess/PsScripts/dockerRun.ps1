#Script to start a container
param(
   [Parameter(Position=0)]
   $image
)
docker run -d $image --daemon