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
                    {/* Stop Button should go here. */}
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
    )
}

export default OperatorInterface