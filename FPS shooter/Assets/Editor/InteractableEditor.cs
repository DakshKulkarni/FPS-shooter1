using UnityEditor;
[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
 
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        if (target.GetType() == typeof(EventsOnlyInteraction))
        {
            interactable.prompt = EditorGUILayout.TextField("Prompt Message", interactable.prompt);
            EditorGUILayout.HelpBox("EventOnlyInteract can use Unity Events only", MessageType.Info);
            if (interactable.GetComponent<InteractionEvents>() == null)
            {
                interactable.UseEvents = true;
                interactable.gameObject.AddComponent<InteractionEvents>();
            }      
        }
        else
        {
            base.OnInspectorGUI();
            if (interactable.UseEvents)
            {
                if (interactable.GetComponent<InteractionEvents>() == null)
                    interactable.gameObject.AddComponent<InteractionEvents>();
            }
            else
            {
                if (interactable.GetComponent<InteractionEvents>() != null)
                    DestroyImmediate(interactable.GetComponent<InteractionEvents>());
            }
        }
    }  
}
