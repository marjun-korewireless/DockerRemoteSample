#Script to list images
docker images --format "table {{.ID}}\t{{.Repository}}\t{{.Tag}}\t\t{{.CreatedAt}}"