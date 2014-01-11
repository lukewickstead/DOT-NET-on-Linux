using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using NUnit.Framework;

namespace Advanced.Collections.Tests
{
	public class ObservableCollectionExampleTests
	{
		[Test ()]
		public void TestCollections ()
		{
			var addCount = 0;
			var removeCount = 0;
			var addSum = 0;
			var removeSum = 0;

			var foo = new ObservableCollection<int> ();

			foo.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => {

				if (e.Action == NotifyCollectionChangedAction.Add) {
					addCount += 1;
					addSum += e.NewItems.Cast<int> ().Sum (x => x);
				}

				if (e.Action == NotifyCollectionChangedAction.Remove) {
					removeCount += 1;
					removeSum += e.OldItems.Cast<int> ().Except (e.NewItems.Cast<int> ()).Sum (x => x);
				}

				foo.Add (1);
				Assert.AreEqual (addCount, 1);
				Assert.AreEqual (addSum, 1);

				foo.Add (2);
				Assert.AreEqual (addCount, 2);
				Assert.AreEqual (addSum, 3);

				foo.Remove (2);
				Assert.AreEqual (addCount, 1);
				Assert.AreEqual (addSum, 2);
			};
		}
	}
}

