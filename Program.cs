using Pulumi;
using Pulumi.AzureNative.Network;
using Pulumi.AzureNative.Network.Inputs;
using Pulumi.AzureNative.Resources;
using System.Threading.Tasks;
using SubnetArgs = Pulumi.AzureNative.Network.SubnetArgs;

class Program
{
    static Task<int> Main() => Pulumi.Deployment.RunAsync<Mystack>();
}

public class Mystack : Stack
{
    public Mystack()
    {
        var resourceGroup = new ResourceGroup("resourceGroup", new()
        {
            ResourceGroupName = "RG-Pulumi",
            Location = "Brazil South",
        });

        var virtualNetwork = new VirtualNetwork("vnet1", new VirtualNetworkArgs
        {
            VirtualNetworkName = "Vnet1",   
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            AddressSpace = new AddressSpaceArgs
            {
                AddressPrefixes = new InputList<string>
                {
                    "10.0.0.0/16"
                }
            }   
         
        });
        var subnet1 = new Subnet("Subnet1", new SubnetArgs
        {
            ResourceGroupName = resourceGroup.Name,
            VirtualNetworkName = virtualNetwork.Name,
            SubnetName = "Subnet1",
            AddressPrefix = "10.0.1.0/24"

        });

        var subnet2 = new Subnet("Subnet2", new SubnetArgs
        {
            ResourceGroupName = resourceGroup.Name,
            VirtualNetworkName = virtualNetwork.Name,
            SubnetName = "Subnet2",
            AddressPrefix = "10.0.2.0/24"

        });

    
    
    
    }
}
