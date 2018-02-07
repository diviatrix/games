using System.Collections;
using System.Collections.Generic;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;

public class Player : PlayerBehavior 
{	
	public GameObject plModel;
	public Animator playerAnimator;

	protected override void NetworkStart()
    {
        base.NetworkStart();
		playerAnimator = plModel.GetComponent<Animator>();

        if (!networkObject.IsOwner)
        {
			return;
        }

        GetComponent<NetworkCamera>().enabled = true;
        GetComponent<Controller>().enabled = true;
        //See @NoMercy's post in #community-answers for this
        //networkObject.position = transform.position;
        networkObject.SnapInterpolations();

        if (NetworkManager.Instance.Networker is IServer)
        {
            //here you can also do some server specific code
        }
        else
        {
            //setup the disconnected event
            NetworkManager.Instance.Networker.disconnected += DisconnectedFromServer;
        }       

    }



	private void FixedUpdate()
	{
		
		// assign networked object position to all who are not owner and exit from Update.
		if (!networkObject.IsOwner)
		{
			GetComponent<Rigidbody>().velocity = networkObject.velocity;
			transform.position = networkObject.position;
			transform.rotation = networkObject.rotation;
            plModel.transform.rotation = networkObject.modelRotation;
			playerAnimator.SetBool("isMoving", networkObject.isMoving);
			playerAnimator.SetBool("isAttacking", networkObject.isAttacking);

			// leave from update, if not owner
			return;
		}

		// says to network instance to update position with client position
		networkObject.position = transform.position;
		networkObject.rotation = transform.rotation;
        networkObject.modelRotation = plModel.transform.rotation;
		networkObject.isMoving = playerAnimator.GetBool("isMoving");
		networkObject.isAttacking = playerAnimator.GetBool("isAttacking");
		//networkObject.velocity = rb.velocity;		
	}

	/// <summary>
    /// Called when a player disconnects
    /// </summary>
    /// <param name="sender"></param>
    private void DisconnectedFromServer(NetWorker sender)
    {
        NetworkManager.Instance.Networker.disconnected -= DisconnectedFromServer;

        MainThreadManager.Run(() =>
        {       
            //Loop through the network objects to see if the disconnected player is the host
            foreach (var no in sender.NetworkObjectList)
            {
                if (no.Owner.IsHost)
                {
                    BMSLogger.Instance.Log("Server disconnected");
                    //Should probably make some kind of "You disconnected" screen. ah well
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                }
            }            
            NetworkManager.Instance.Disconnect();
        });
    }

	private void OnApplicationQuit()
	{
		NetWorker.EndSession();		
	}
}