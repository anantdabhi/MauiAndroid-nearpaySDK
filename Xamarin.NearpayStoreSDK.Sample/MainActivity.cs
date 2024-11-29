using IO.Nearpay.Sdk;
using IO.Nearpay.Sdk.Utils;
using IO.Nearpay.Sdk.Utils.Enums;
using IO.Nearpay.Sdk.Utils.Listeners;
using static Java.Interop.JniEnvironment;

namespace Sample
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {

        NearPay? nearpay;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            var nearPayBuilder = new NearPay.Builder()
                                .Context(this)
                                .Locale(Java.Util.Locale.Default)
                                .AuthenticationData(IO.Nearpay.Sdk.Utils.Enums.AuthenticationData.UserEnter.Instance)
                                .Environment(IO.Nearpay.Sdk.Environments.Sandbox)
                                .NetworkConfiguration(IO.Nearpay.Sdk.Utils.Enums.NetworkConfiguration.SimPreferred)
                                .UiPosition(IO.Nearpay.Sdk.Utils.Enums.UIPosition.CenterBottom)
                                .PaymentText((new PaymentText("يرجى تمرير الطاقة", "please tap your card")))
                                .LoadingUi(true).Build();
            var setupListner = new NearpaySetupListner();
            nearPayBuilder.Setup(setupListner);
            nearpay = nearPayBuilder;
            setupListner.OnSetupCompletedEvent += SetupListner_OnSetupCompletedEvent;
        }

        private void SetupListner_OnSetupCompletedEvent()
        {
            nearpay.Purchase(500, "123", true, true, 600, Java.Util.UUID.FromString(Guid.NewGuid().ToString()), true, new PurchaseListener());
        }



    }
    public class PurchaseListener : Java.Lang.Object, IO.Nearpay.Sdk.Utils.Listeners.IPurchaseListener
    {
        public void OnPurchaseApproved(TransactionData transactionData)
        {
            String receipt = ReceiptUtilsKt.ToJson(transactionData.Receipts.First());

        }

        public void OnPurchaseFailed(PurchaseFailure purchaseFailure)
        {

        }
    }
    public class NearpaySetupListner : Java.Lang.Object, IO.Nearpay.Sdk.Utils.Listeners.ISetupListener //io.nearpay.sdk.utils.enums.SetupFailur
    {
        public delegate void OnSetupCompletedHandler();
        public event OnSetupCompletedHandler OnSetupCompletedEvent;

        public void OnSetupCompleted()
        {
            OnSetupCompletedEvent?.Invoke();
        }

        public void OnSetupFailed(SetupFailure setupFailure)
        {

        }

        private void MakeTransaction(NearPay nearPay)
        {

        }

    }
}