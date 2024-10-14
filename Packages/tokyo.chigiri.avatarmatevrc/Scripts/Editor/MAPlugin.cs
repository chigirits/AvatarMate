using nadena.dev.ndmf;

[assembly: ExportsPlugin(typeof(tokyo.chigiri.avatarmatevrc.editor.AvatarMatePlugin))]

namespace tokyo.chigiri.avatarmatevrc.editor
{

    public class AvatarMatePlugin: Plugin<AvatarMatePlugin>
    {
        protected override void Configure()
        {
            InPhase(BuildPhase.Resolving).Run("AvatarMate", ctx =>
            {
                foreach (var c in ctx.AvatarRootObject.GetComponentsInChildren<MAViewPositionProxy>(true))
                {
                    MAViewPositionProxy.DestroyImmediate(c);
                }
                foreach (var c in ctx.AvatarRootObject.GetComponentsInChildren<MAStartupActivity>(true))
                {
                    c.DoEffect();
                    MAStartupActivity.DestroyImmediate(c);
                }
            });
        }
    }

}
