import "./OperatorInterface.css"

export function OperatorInterface() {
    return (

        <div className="operator-page">
            <header className="operator-header">
                <div className="operator-brand">
                    <h1>iBUSIM</h1>
                    <p>Cockpit Integration &amp; Operator Console</p>
                </div>

                <div className="operator-header-actions">
                    <button
                        id="square-action"
                        style={{
                            width: 50,
                            height: 50,
                            padding: 0,
                            borderRadius: 0,
                            fontSize: 12
                        }}
                    >
                        Stop
                    </button>
                </div>
            </header>

            <main className="operator-main">
                <section className="operator-page-heading">
                    <h1>Operator Interface</h1>
                </section>

                <div className="operator-layout">
                    <section className="operator-status">
                        {/* Status panel goes here */}
                    </section>

                    <section className="operator-cockpit">
                        {/* Cockpit controls go here */}
                    </section>
                </div>
            </main>
        </div>
>>>>>>> d9820b29bd1749cef1a1853cb543cc7bb1ff04ca
    )
}

export default OperatorInterface