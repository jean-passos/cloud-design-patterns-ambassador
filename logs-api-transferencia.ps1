kubectl rollout restart deployment/deployment-api-transferencia
kubectl rollout status deployment/deployment-api-transferencia
$podApiTransfernecia =  kubectl get pods -l app=api-transferencia -o jsonpath='{.items[0].metadata.name}'
$podApiTransfernecia
kubectl logs $podApiTransfernecia -f